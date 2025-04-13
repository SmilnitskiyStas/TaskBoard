using FluentValidation;
using TaskBoard_Api.Features.Tasks.DTOs;

namespace TaskBoard_Api.Features.Tasks.Validators
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskItemDto>
    {
        public UpdateTaskDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Name`s require")
                .MaximumLength(100).WithMessage("Maximum length 100 simbols");

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid task status");
        }
    }
}
