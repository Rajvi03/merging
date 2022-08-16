using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPractice.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class doctorController : ControllerBase
    {
        private IDoctorService doctorService { get; set; }

        public doctorController(IDoctorService Service)
        {
            doctorService = Service;
        }
        [HttpGet]
        public IActionResult getDoctor(Doctor doctor)
        {
            return Ok(doctorService.GetAll(doctor));
        }
    }
}
