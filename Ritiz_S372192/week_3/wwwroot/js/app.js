$(document).ready(function() {
    console.log('Document ready, initializing application...');
    
    // Show initial status
    if (typeof showStatus === 'function') {
        showStatus('Application loaded successfully!', 'success');
    }
    
    // Load initial data
    loadCategories();
    loadMovies();
    
    // Set up form handlers
    $('#categoryForm').on('submit', handleCategorySubmit);
    $('#movieForm').on('submit', handleMovieSubmit);
    
    console.log('Application initialized successfully');
});

// API Base URL
const API_BASE = '/api';

// Category Functions
function loadCategories() {
    console.log('Loading categories...');
    $.ajax({
        url: `${API_BASE}/Categories`,
        method: 'GET',
        success: function(data) {
            console.log('Categories loaded:', data);
            displayCategories(data);
            updateCategoryDropdown(data);
            if (typeof showStatus === 'function') {
                showStatus('Categories loaded successfully!', 'success');
            }
        },
        error: function(xhr, status, error) {
            console.error('Error loading categories:', error);
            console.error('Response:', xhr.responseText);
            if (typeof showStatus === 'function') {
                showStatus('Error loading categories: ' + error, 'danger');
            } else {
                alert('Error loading categories: ' + error);
            }
        }
    });
}

function displayCategories(categories) {
    const tbody = $('#categoriesTable tbody');
    tbody.empty();
    
    categories.forEach(function(category) {
        const row = `
            <tr>
                <td>${category.id}</td>
                <td>${category.name}</td>
                <td>${category.code}</td>
                <td>
                    <button class="btn btn-sm btn-warning" onclick="editCategory(${category.id})">Edit</button>
                    <button class="btn btn-sm btn-danger" onclick="deleteCategory(${category.id})">Delete</button>
                </td>
            </tr>
        `;
        tbody.append(row);
    });
}

function updateCategoryDropdown(categories) {
    const dropdown = $('#movieCategory');
    dropdown.find('option:not(:first)').remove();
    
    categories.forEach(function(category) {
        dropdown.append(`<option value="${category.id}">${category.name}</option>`);
    });
}

function handleCategorySubmit(e) {
    e.preventDefault();
    
    const category = {
        id: $('#categoryId').val() || 0,
        name: $('#categoryName').val(),
        code: $('#categoryCode').val()
    };
    
    const method = category.id > 0 ? 'PUT' : 'POST';
    const url = category.id > 0 ? `${API_BASE}/Categories/${category.id}` : `${API_BASE}/Categories`;
    
    $.ajax({
        url: url,
        method: method,
        contentType: 'application/json',
        data: JSON.stringify(category),
        success: function(data) {
            loadCategories();
            resetCategoryForm();
            alert('Category saved successfully!');
        },
        error: function(xhr, status, error) {
            alert('Error saving category: ' + error);
        }
    });
}

function editCategory(id) {
    $.ajax({
        url: `${API_BASE}/Categories/${id}`,
        method: 'GET',
        success: function(category) {
            $('#categoryId').val(category.id);
            $('#categoryName').val(category.name);
            $('#categoryCode').val(category.code);
        },
        error: function(xhr, status, error) {
            alert('Error loading category: ' + error);
        }
    });
}

function deleteCategory(id) {
    if (confirm('Are you sure you want to delete this category?')) {
        $.ajax({
            url: `${API_BASE}/Categories/${id}`,
            method: 'DELETE',
            success: function() {
                loadCategories();
                alert('Category deleted successfully!');
            },
            error: function(xhr, status, error) {
                alert('Error deleting category: ' + error);
            }
        });
    }
}

function resetCategoryForm() {
    $('#categoryId').val('');
    $('#categoryName').val('');
    $('#categoryCode').val('');
}

// Movie Functions
function loadMovies() {
    console.log('Loading movies...');
    $.ajax({
        url: `${API_BASE}/Movies`,
        method: 'GET',
        success: function(data) {
            console.log('Movies loaded:', data);
            displayMovies(data);
            if (typeof showStatus === 'function') {
                showStatus('Movies loaded successfully!', 'success');
            }
        },
        error: function(xhr, status, error) {
            console.error('Error loading movies:', error);
            console.error('Response:', xhr.responseText);
            if (typeof showStatus === 'function') {
                showStatus('Error loading movies: ' + error, 'danger');
            } else {
                alert('Error loading movies: ' + error);
            }
        }
    });
}

function displayMovies(movies) {
    const tbody = $('#moviesTable tbody');
    tbody.empty();
    
    const languages = ['English', 'Japanese', 'Chinese'];
    
    movies.forEach(function(movie) {
        const row = `
            <tr>
                <td>${movie.id}</td>
                <td>${movie.name}</td>
                <td>${new Date(movie.releaseDate).toLocaleDateString()}</td>
                <td>${movie.director}</td>
                <td>${languages[movie.language]}</td>
                <td>${movie.category ? movie.category.name : 'N/A'}</td>
                <td>
                    <button class="btn btn-sm btn-warning" onclick="editMovie(${movie.id})">Edit</button>
                    <button class="btn btn-sm btn-danger" onclick="deleteMovie(${movie.id})">Delete</button>
                </td>
            </tr>
        `;
        tbody.append(row);
    });
}

function handleMovieSubmit(e) {
    e.preventDefault();
    
    const movie = {
        id: $('#movieId').val() || 0,
        name: $('#movieName').val(),
        releaseDate: $('#movieReleaseDate').val(),
        director: $('#movieDirector').val(),
        contactEmailAddress: $('#movieEmail').val(),
        language: parseInt($('#movieLanguage').val()),
        categoryId: parseInt($('#movieCategory').val())
    };
    
    const method = movie.id > 0 ? 'PUT' : 'POST';
    const url = movie.id > 0 ? `${API_BASE}/Movies/${movie.id}` : `${API_BASE}/Movies`;
    
    $.ajax({
        url: url,
        method: method,
        contentType: 'application/json',
        data: JSON.stringify(movie),
        success: function(data) {
            loadMovies();
            resetMovieForm();
            alert('Movie saved successfully!');
        },
        error: function(xhr, status, error) {
            alert('Error saving movie: ' + error);
        }
    });
}

function editMovie(id) {
    $.ajax({
        url: `${API_BASE}/Movies/${id}`,
        method: 'GET',
        success: function(movie) {
            $('#movieId').val(movie.id);
            $('#movieName').val(movie.name);
            $('#movieReleaseDate').val(movie.releaseDate.split('T')[0]);
            $('#movieDirector').val(movie.director);
            $('#movieEmail').val(movie.contactEmailAddress);
            $('#movieLanguage').val(movie.language);
            $('#movieCategory').val(movie.categoryId);
        },
        error: function(xhr, status, error) {
            alert('Error loading movie: ' + error);
        }
    });
}

function deleteMovie(id) {
    if (confirm('Are you sure you want to delete this movie?')) {
        $.ajax({
            url: `${API_BASE}/Movies/${id}`,
            method: 'DELETE',
            success: function() {
                loadMovies();
                alert('Movie deleted successfully!');
            },
            error: function(xhr, status, error) {
                alert('Error deleting movie: ' + error);
            }
        });
    }
}

function resetMovieForm() {
    $('#movieId').val('');
    $('#movieName').val('');
    $('#movieReleaseDate').val('');
    $('#movieDirector').val('');
    $('#movieEmail').val('');
    $('#movieLanguage').val('0');
    $('#movieCategory').val('');
}
