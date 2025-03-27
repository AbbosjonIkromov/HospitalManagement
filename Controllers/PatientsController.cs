using HospitalManagement.DataAccess.Entities;
using HospitalManagement.Dtos;
using HospitalManagement.Dtos.Appointment;
using HospitalManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog.Context;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<PatientsController> _logger;
        private readonly IPatientService _patientService;
        private readonly DoctorSettings _doctorSettings;

        public PatientsController(
            IOptions<DoctorSettings> doctorSettingSnap,
            IConfiguration configuration,
            ILogger<PatientsController> logger,
            IPatientService patientService)  
        {
            _doctorSettings = doctorSettingSnap.Value;
            _configuration = configuration;
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientService.GetAll();

            return Ok(patients);
        }

        [HttpPost("arrange-appointment")]

        public async Task<IActionResult> ArrangeAppointment([FromBody] ArrangeAppointmentDto requestDto)
        {
            using (LogContext.PushProperty("PatientId", requestDto.PatientId))
            {
                var time = TimeOnly.FromDateTime(requestDto.AppointmentDate);

                if (!time.IsBetween(_doctorSettings.WorkTime.Start, _doctorSettings.WorkTime.Stop))
                {
                    _logger.LogWarning("Doctor is not available at this time");

                    return BadRequest("Doctor is not available this time");
                }

                _logger.LogWarning("{@Request}, Patient with PasswordSerial {PasswordSerial}", requestDto, requestDto.PasswordSerial);
            }

            return Ok("Your appointment is arranged");
        }
    }
}
