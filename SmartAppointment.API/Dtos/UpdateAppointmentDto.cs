using System;
using System.ComponentModel.DataAnnotations;

namespace SmartAppointment.API.Dtos
{
	public class UpdateAppointmentDto
	{
		[Required]
		public string FullName { get; set; } = null!;

		[Required]
		[EmailAddress]
		public string Email { get; set; } = null!;

		[Required]
		public DateTime AppointmentDate { get; set; }

		public string? Description { get; set; }
	}
}
