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
        private readonly IStringLocalizer<SharedResources> _localizer;

        public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _localizer = localizer;
            ApplyCustomValidations();
        }
        public void ApplyValidationsRules()
        {

        }

        public void ApplyCustomValidations()
        {
            RuleFor(n => n.Name)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
                 .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
    }
}
