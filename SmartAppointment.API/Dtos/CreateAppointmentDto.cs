using System;
using System.ComponentModel.DataAnnotations;

namespace SmartAppointment.API.Dtos
{
	public class CreateAppointmentDto
	{
		public string FullName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public DateTime AppointmentDate { get; set; }
		public string? Description { get; set; }
	}
}
