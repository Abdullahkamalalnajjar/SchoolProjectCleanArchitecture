using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentValidator :AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public EditStudentValidator(IStudentService studentService, IDepartmentService departmentService,IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _localizer = localizer;
            ApplyCustomValidations();
        }

        public void ApplyCustomValidations()
        {
            RuleFor(n => n.Name)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
                 .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            
            RuleFor(d => d.DepartmentId)
                .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.DepartmentIsNotExist]);
        }
    }
}
