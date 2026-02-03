using FluentValidation;
using SmartAppointment.API.Dtos;

namespace SmartAppointment.API.Validators
{
	public class CreateAppointmentDtoValidator
		: AbstractValidator<CreateAppointmentDto>
	{
		public CreateAppointmentDtoValidator()
		{
			RuleFor(x => x.FullName)
				.NotEmpty()
				.MinimumLength(3);

			RuleFor(x => x.Email)
				.NotEmpty()
				.EmailAddress();

			RuleFor(x => x.AppointmentDate)
				.GreaterThan(DateTime.Now);

			RuleFor(x => x.Description)
				.MaximumLength(500);
		}
	}
}
