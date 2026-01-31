using System;
namespace SmartAppointment.API.Models
{
	public class Appointment
	{
		public int Id { get; set; }

		public string FullName { get; set; } = null!;

		public string Email { get; set; } = null!; 

		public DateTime AppointmentDate { get; set; }

		public string? Description	{ get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	}
}
