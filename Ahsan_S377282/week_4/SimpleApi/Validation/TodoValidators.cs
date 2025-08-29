using FluentValidation;
using SimpleApi.Contracts;

namespace SimpleApi.Validation;

public class CreateTodoValidator : AbstractValidator<CreateTodo>
{
    public CreateTodoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Text is required")
            .MaximumLength(200);
    }
}

public class UpdateTodoValidator : AbstractValidator<UpdateTodo>
{
    public UpdateTodoValidator()
    {
        RuleFor(x => x.Text)
            .MaximumLength(200)
            .When(x => x.Text is not null);
    }
}
