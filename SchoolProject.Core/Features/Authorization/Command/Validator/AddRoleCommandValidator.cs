using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authorization.Command.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Authorization.Command.Validator;

public class AddRoleCommandValidator:AbstractValidator<AddRoleCommand>
{
    private readonly IStringLocalizer<SharedResources> _localizer;
    private readonly IAuthorizationService _authorizationService;

    public AddRoleCommandValidator(IStringLocalizer<SharedResources> localizer,IAuthorizationService authorizationService)
    {
        _localizer = localizer;
        _authorizationService = authorizationService;
        ApplyValidation();
        ApplyValidationFailure();
    }

    private void ApplyValidation()
    {
        RuleFor(n=>n.RoleName)
            .NotEmpty()
            .WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
    }

    private void ApplyValidationFailure()
    {
        RuleFor(n => n.RoleName)
            .MustAsync(async (key, cancellationtoken) => !await  _authorizationService.IsExistRole(key))
            .WithMessage(_localizer[SharedResourcesKeys.RoleIsExist]);
    }
}