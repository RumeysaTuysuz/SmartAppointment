using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartAppointment.API.Data;
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
	}
}
