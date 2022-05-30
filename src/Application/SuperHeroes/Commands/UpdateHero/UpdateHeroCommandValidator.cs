using FluentValidation;

namespace Application.Superheroes.Commands.UpdateHero;

public class UpdateHeroCommandValidator : AbstractValidator<UpdateHeroCommand>
{
    public UpdateHeroCommandValidator()
    {
        RuleFor(v => v.SuperheroName)
            .MaximumLength(200)
            .NotEmpty();
    }
}