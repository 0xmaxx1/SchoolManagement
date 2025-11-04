using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Student.Commands.Models;
using SchoolManagement.Services.Abstraction;

namespace SchoolManagement.Core.Features.Student.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources.SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;

        //public AddStudentValidator()
        //{

        //}

        public AddStudentValidator(IStudentService studentService,
            IStringLocalizer<SharedResources.SharedResources> localizer,
            IDepartmentService departmentService)
        {
            this._studentService = studentService;
            this._localizer = localizer;
            this._departmentService = departmentService;
            ApplyValidationsRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                //.NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotEmpty().WithMessage(_localizer[SharedResources.SharedResourcesKeys.Empty])
                .NotNull().WithMessage("{PropertyValue} must not be null")
                .MaximumLength(15).WithMessage("max length is 15");

            RuleFor(x => x.Address)
                //.NotEmpty().WithMessage("{PropertyName} must not be empty")
                .NotEmpty().WithMessage(_localizer[SharedResources.SharedResourcesKeys.Empty])
                .NotNull().WithMessage("must not be null")
                .MaximumLength(15).WithMessage("max length for {PropertyName} is 15");

            RuleFor(X => X.DepartmentId)
                .NotEmpty().WithMessage(_localizer[SharedResources.SharedResourcesKeys.Empty])
                .NotNull().WithMessage("must not be null");


        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                .WithMessage("The Name is already taken.");

            //When(x => x.DepartmentId != 0, () =>
            //{

            RuleFor(x => x.DepartmentId)
                    .MustAsync(async (key, CancellationToken) => await _departmentService.IsDepartmentIdExist(key))
                    .WithMessage(_localizer[SharedResources.SharedResourcesKeys.IsNotExist]);
            //});



        }



    }
}
