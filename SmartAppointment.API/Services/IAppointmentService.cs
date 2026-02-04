using SmartAppointment.API.Models;

namespace SmartAppointment.API.Services
{
	public interface IAppointmentService
	{
		Task<List<Appointment>> GetAllAsync();
		Task<Appointment?> GetByIdAsync(int id);
		Task<Appointment> CreateAsync(Appointment appointment);
		Task<bool> UpdateAsync(Appointment appointment);
		Task<bool> DeleteAsync(int id);
	}
}
