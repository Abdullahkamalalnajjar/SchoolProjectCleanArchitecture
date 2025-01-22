using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Command.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Users.Command.Validator;

public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
{
    private readonly IAppUserService _appUserService;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public EditUserCommandValidator(IAppUserService appUserService,IStringLocalizer<SharedResources> localizer)
    {
        _appUserService = appUserService;
        _localizer = localizer;
    }

    public void EditUserValidator()
    {
        RuleFor(e => e.Email).MustAsync(async (model, Key, CancellationToken) =>
            !await _appUserService.IsEmailExistExcludeSelf(model.Id, model.Email)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);
    }
}