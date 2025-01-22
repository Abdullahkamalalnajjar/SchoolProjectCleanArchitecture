using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Model;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Authentication.Validator;

public class SiginValidator:AbstractValidator<SignInCommand>
{
    private readonly IStringLocalizer<SharedResources> _localizer;

    public SiginValidator(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
    }

    public void AddSigninValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty].Value)
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty].Value)
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
    }
}