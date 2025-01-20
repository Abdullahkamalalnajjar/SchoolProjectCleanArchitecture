using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public AddStudentValidator(IStudentService studentService, IDepartmentService departmentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationsRules();
            ApplyCustomValidations();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty].Value)
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.Address)
            .NotEmpty().WithMessage("{PropertyName} Must Not Be Empty")
            .MaximumLength(10).WithMessage("{PropertyName} Maximun 10 char")
            .NotNull().WithMessage("{PropertyName} Must Not Be Null");
        }

        public void ApplyCustomValidations()
        {
            RuleFor(n => n.Name)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsExist]);

            RuleFor(d => d.DepartmentId)
               .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentExist(Key))
               .WithMessage(_stringLocalizer[SharedResourcesKeys.DepartmentIsNotExist]);
        }

    }
}
