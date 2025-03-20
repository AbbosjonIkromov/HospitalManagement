using HospitalManagement.DataAccess.Entities;
using HospitalManagement.Dtos;
using HospitalManagement.Dtos.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IOptionsSnapshot<DoctorSettings> _doctorSettingSnap;
        private readonly IOptionsMonitor<DoctorSettings> _doctorSettingMonitor;
        private readonly ILogger<PatientsController> _logger;
        private readonly DoctorSettings _options;

        public PatientsController(
            IOptions<DoctorSettings> options,
            IOptionsSnapshot<DoctorSettings> doctorSettingSnap,
            IOptionsMonitor<DoctorSettings> doctorSettingMonitor,
            ILogger<PatientsController> logger)  
        {
            _doctorSettingSnap = doctorSettingSnap;
            _doctorSettingMonitor = doctorSettingMonitor;
            _logger = logger;
            _options = options.Value;
        }
        [HttpPost("arrange-appointment")]
        public async Task<IActionResult> ArrangeAppointment([FromBody] ArrangeAppointmentDto requestDto)
        {
            var time = TimeOnly.FromDateTime(requestDto.AppointmentDate);
            var start = _options.WorkTime.Start;
            var stop = _options.WorkTime.Stop;

            if (!time.IsBetween(start, stop))
            {

                _logger.LogWarning("Invalid Time");
                return BadRequest("Doctor is not available at this time");
            }

            _logger.LogInformation("Accepted");
            return Ok("Your appointment is arranged");
        }
    }
}
