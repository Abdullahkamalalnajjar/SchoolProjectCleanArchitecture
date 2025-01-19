using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Departments.Commands.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Departments.Commands.Validators
{
    public class EditDepartmentCommandValidator : AbstractValidator<EditDepartmentCommand>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public EditDepartmentCommandValidator(IDepartmentService departmentService, IStringLocalizer<SharedResources> localizer)
        {
            _departmentService = departmentService;
            _localizer = localizer;
            CustomEditCommandValidator();
        }

        public void CustomEditCommandValidator()
        {
            RuleFor(n => n.Name)
     .MustAsync(async (model, Key, CancellationToken) => !await _departmentService.IsNameExistExcludeSelf(model.Id, Key))
      .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
    }
}
