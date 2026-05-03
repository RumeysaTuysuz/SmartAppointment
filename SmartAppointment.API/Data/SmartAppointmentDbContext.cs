using SmartAppointment.API.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartAppointment.API.Data
{
	public class SmartAppointmentDbContext : DbContext
	{
		public SmartAppointmentDbContext(DbContextOptions<SmartAppointmentDbContext> options)
			: base(options)
		{
		}

		public DbSet<Appointment> Appointments { get; set; } = null!;

		// public DbSet<Appointment> Appointments { get; set; }
	}
}
