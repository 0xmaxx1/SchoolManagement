using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.User.Commands.Models;

namespace SchoolManagement.Core.Features.User.Commands.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IStringLocalizer<SharedResources.SharedResources> _localizer;

        public AddUserValidator(IStringLocalizer<SharedResources.SharedResources> localizer)
        {
            this._localizer = localizer;
            ApplyValidationsRules();
        }


        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Empty])
                .NotNull()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Required]);
            //.MaximumLength(100).WithMessage(_localizer[SharedResources.SharedResourcesKeys]);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Empty])
                .NotNull()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Required]);

            //.MaximumLength(100).WithMessage(_localizer[SharedResources.SharedResourcesKeys]);



            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Empty])
                .NotNull()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Required]);
            //.MaximumLength(100).WithMessage(_localizer[SharedResources.SharedResourcesKeys]);


            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Empty])
                .NotNull()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Required]);
            //.MaximumLength(100).WithMessage(_localizer[SharedResources.SharedResourcesKeys]);



            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Empty])
                .NotNull()
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.Required])
                .Equal(x => x.Password)
                .WithMessage(_localizer[SharedResources.SharedResourcesKeys.PasswordNotEqualConfirmPass]);
            //.MaximumLength(100).WithMessage(_localizer[SharedResources.SharedResourcesKeys]);






        }




    }
}
