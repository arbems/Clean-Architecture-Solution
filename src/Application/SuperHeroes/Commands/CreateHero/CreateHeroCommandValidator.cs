using FluentValidation;

namespace Application.Superheroes.Commands.CreateHero;

public class CreateHeroCommandValidator : AbstractValidator<CreateHeroCommand>
{
    public CreateHeroCommandValidator()
    {
        RuleFor(v => v.SuperheroName)
            .MaximumLength(200)
            .NotEmpty();
    }
}