using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Command.Model;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Users.Command.Validator;

public class AddUserCommandValidator:AbstractValidator<AddUserCommand>
{
    private readonly IStringLocalizer<SharedResources> _localizer;

    public AddUserCommandValidator(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
        ApplyAddUserValidator();
    }

    private void ApplyAddUserValidator()
    {
        RuleFor(us => us.Username)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
        RuleFor(p => p.Password)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
        RuleFor(p => p.ConfirmPassword)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
        RuleFor(p => p.PhoneNumber)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
        
        RuleFor(p => p.ConfirmPassword)
            .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.ConfirmPasswordNotMatch]);
    }
    
}