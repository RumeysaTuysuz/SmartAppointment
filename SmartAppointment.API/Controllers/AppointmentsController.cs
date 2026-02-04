using Microsoft.AspNetCore.Mvc;
using SmartAppointment.API.Dtos;
using SmartAppointment.API.Models;
using SmartAppointment.API.Services;

namespace SmartAppointment.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AppointmentsController : ControllerBase
	{
		private readonly IAppointmentService _appointmentService;

		public AppointmentsController(IAppointmentService appointmentService)
		{
			_appointmentService = appointmentService;
		}

		// GET: api/appointments
		[HttpGet]
		public async Task<ActionResult<ApiResponse<IEnumerable<Appointment>>>> GetAppointments()
		{
			var appointments = await _appointmentService.GetAllAsync();

			return Ok(new ApiResponse<IEnumerable<Appointment>>
			{
				Success = true,
				Message = "Appointments retrieved successfully",
				Data = appointments
			});
		}

		// POST: api/appointments
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

			var created = await _appointmentService.CreateAsync(appointment);

			return StatusCode(
				StatusCodes.Status201Created,
				new ApiResponse<Appointment>
				{
					Success = true,
					Message = "Appointment created successfully",
					Data = created
				}
			);
		}

		// PUT: api/appointments/{id}
		[HttpPut("{id}")]
		public async Task<ActionResult<ApiResponse<Appointment>>> UpdateAppointment(
			int id,
			CreateAppointmentDto dto)
		{
			var appointment = await _appointmentService.GetByIdAsync(id);

			if (appointment == null)
			{
				return NotFound(new ApiResponse<Appointment>
				{
					Success = false,
					Message = "Appointment not found"
				});
			}

			appointment.FullName = dto.FullName;
			appointment.Email = dto.Email;
			appointment.AppointmentDate = dto.AppointmentDate;
			appointment.Description = dto.Description;

			var updated = await _appointmentService.UpdateAsync(appointment);

			if (!updated)
			{
				return BadRequest(new ApiResponse<Appointment>
				{
					Success = false,
					Message = "Appointment could not be updated"
				});
			}

			return Ok(new ApiResponse<Appointment>
			{
				Success = true,
				Message = "Appointment updated successfully",
				Data = appointment
			});
		}

		// DELETE: api/appointments/{id}
		[HttpDelete("{id}")]
		public async Task<ActionResult<ApiResponse<object>>> DeleteAppointment(int id)
		{
			var deleted = await _appointmentService.DeleteAsync(id);

			if (!deleted)
			{
				return NotFound(new ApiResponse<object>
				{
					Success = false,
					Message = "Appointment not found"
				});
			}

			return Ok(new ApiResponse<object>
			{
				Success = true,
				Message = "Appointment deleted successfully"
			});
		}
	}
}
