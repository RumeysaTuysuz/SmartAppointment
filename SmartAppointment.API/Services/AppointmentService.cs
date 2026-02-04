using Microsoft.EntityFrameworkCore;
using SmartAppointment.API.Data;
using SmartAppointment.API.Models;

namespace SmartAppointment.API.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly SmartAppointmentDbContext _context;

		public AppointmentService(SmartAppointmentDbContext context)
		{
			_context = context;
		}

		public async Task<List<Appointment>> GetAllAsync()
		{
			return await _context.Appointments.ToListAsync();
		}

		public async Task<Appointment?> GetByIdAsync(int id)
		{
			return await _context.Appointments.FindAsync(id);
		}

		public async Task<Appointment> CreateAsync(Appointment appointment)
		{
			_context.Appointments.Add(appointment);
			await _context.SaveChangesAsync();
			return appointment;
		}

		public async Task<bool> UpdateAsync(Appointment appointment)
		{
			_context.Appointments.Update(appointment);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var appointment = await _context.Appointments.FindAsync(id);
			if (appointment == null)
				return false;

			_context.Appointments.Remove(appointment);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
