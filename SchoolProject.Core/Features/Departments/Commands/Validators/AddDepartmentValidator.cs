using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Departments.Commands.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Departments.Commands.Validators
{
    public class AddDepartmentValidator : AbstractValidator<AddDepartmentCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;

        public AddDepartmentValidator(IStringLocalizer<SharedResources> localizer, IDepartmentService departmentService)
        {
            _localizer = localizer;
            _departmentService = departmentService;
            ApplyDepartmentValidator();
            CustomApplyDepartmentValidator();
        }

        public IStringLocalizer<SharedResources> Localizer { get; }

        public void ApplyDepartmentValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty()
                .WithMessage(_localizer[SharedResourcesKeys.NotEmpty]);
        }
        public void CustomApplyDepartmentValidator()
        {
            RuleFor(n => n.Name)
                .MustAsync(async (key, CancellationToken) => !await _departmentService.IsNameExist(key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
    }
}
