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
		public async Task<ActionResult<ApiResponse<IEnumerable<Appointment>>>> GetAppointments()
		{
			var appointments = await _context.Appointments.ToListAsync();

			var response = new ApiResponse<IEnumerable<Appointment>>
			{
				Success = true,
				Message = "Appointments retrieved successfully",
				Data = appointments,
				Errors = null
			};

			return Ok(response);
		}


		[HttpPost]
		public async Task<IActionResult> CreateAppointment(CreateAppointmentDto dto)
		{
			var appointment = new Appointment
			{
				FullName = dto.FullName,
				Email = dto.Email,
				AppointmentDate = dto.AppointmentDate,
				Description = dto.Description
			};

			_context.Appointments.Add(appointment);
			await _context.SaveChangesAsync();

			return StatusCode(
				StatusCodes.Status201Created,
				ApiResponse<Appointment>.SuccessResponse(
					appointment,
					"Appointment created successfully"
				)
			);
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAppointment(int id, UpdateAppointmentDto dto)
		{
			var appointment = await _context.Appointments.FindAsync(id);

			if (appointment == null)
				return NotFound();

			appointment.FullName = dto.FullName;
			appointment.Email = dto.Email;
			appointment.AppointmentDate = dto.AppointmentDate;
			appointment.Description = dto.Description;

			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAppointment(int id)
		{
			var appointment = await _context.Appointments.FindAsync(id);

			if (appointment == null)
				return NotFound();

			_context.Appointments.Remove(appointment);
			await _context.SaveChangesAsync();

			return NoContent();
		}


	}
}
