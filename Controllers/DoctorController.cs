using HospitalManagement.Dtos.Doctor;
using HospitalManagement.Services;
using HospitalManagement.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;
        private readonly IConfiguration _configuration;
        private readonly PdpService _pdpService;

        public DoctorController(IDoctorService service,
            IConfiguration configuration,
            PdpService pdpService)
        {
            doctorService = service;
            _configuration = configuration;
            _pdpService = pdpService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await doctorService.GetAllDoctors();

            return Ok(doctors);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto doctorDto)
        {
            await doctorService.CreateDoctor(doctorDto);

            return Created();
        }

        [HttpGet("get-pdpSettings")]
        public async Task<IActionResult> GetPdpSetting()
        {
            return Ok(await _pdpService.GetPdpData());
        }

    }
}
