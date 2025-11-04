using FluentValidation;
using SchoolManagement.Core.Features.Student.Commands.Models;
using SchoolManagement.Services.Abstraction;

namespace SchoolManagement.Core.Features.Student.Commands.Validations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        public EditStudentValidator(IStudentService studentService)
        {
            this._studentService = studentService;
            ApplyValidationsRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyValue} must not be null")
                .MaximumLength(15).WithMessage("max length is 15");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotNull().WithMessage("{PropertyValue} must not be null")
                .MaximumLength(15).WithMessage("max length for {PropertyName} is 15");

        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(key, model.Id))
                .WithMessage("The Name is already taken.");
        }

    }
}
