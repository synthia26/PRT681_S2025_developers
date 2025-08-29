/* global $ */

export function showToast(target, message, isError = false) {
  const toast = $('<div class="toast">').text(message);
  if (isError) toast.addClass('error');
  $(target).empty().append(toast);
}

export async function api(url, options = {}) {
  const merged = Object.assign({ headers: { 'Content-Type': 'application/json' } }, options);
  const response = await fetch(url, merged);
  if (!response.ok) {
    let problem;
    try { problem = await response.json(); } catch { /* ignore */ }
    const message = problem?.title || problem?.detail || `Request failed (${response.status})`;
    const errors = problem?.errors ? flattenProblemErrors(problem.errors) : null;
    const err = new Error(message);
    err.status = response.status;
    err.problem = problem;
    err.validation = errors;
    throw err;
  }
  if (response.status === 204) return null;
  const text = await response.text();
  return text ? JSON.parse(text) : null;
}

function flattenProblemErrors(errors) {
  const list = [];
  for (const key in errors) {
    if (Object.prototype.hasOwnProperty.call(errors, key)) {
      const msgs = errors[key];
      for (const m of msgs) list.push({ field: key, message: m });
    }
  }
  return list;
}

