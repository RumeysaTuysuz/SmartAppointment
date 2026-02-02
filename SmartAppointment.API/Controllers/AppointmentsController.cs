using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartAppointment.API.Data;
using SmartAppointment.API.Dtos;
using SmartAppointment.API.Models;

namespace SmartAppointment.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AppointmentsController : ControllerBase
	{

		private readonly SmartAppointmentDbContext _context;

		public AppointmentsController(SmartAppointmentDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
		{
			var appointments = await _context.Appointments.ToListAsync();
			return Ok(appointments);
		}

		[HttpPost]
		public async Task<ActionResult> CreateAppointment(CreateAppointmentDto dto)
		{
			var appointment = new Appointment
			{
				FullName = dto.FullName,
				Email = dto.Email,
				AppointmentDate = dto.AppointmentDate,
				Description = dto.Description
				// CreatedAt otomatik set ediliyor
			};

			_context.Appointments.Add(appointment);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetAppointments), new { id = appointment.Id }, appointment);
		}



	}
}
