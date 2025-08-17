namespace SimpleApi.Contracts;

public record CreateTodo(string Text);
public record UpdateTodo(string? Text, bool? Done);
