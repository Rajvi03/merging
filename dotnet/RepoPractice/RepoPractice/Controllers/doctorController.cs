using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class doctorController : ControllerBase
    {
        private IDoctorService doctorService { get; set; }

        public doctorController(IDoctorService Service)
        {
            doctorService = Service;
        }
        [HttpGet]
        public IActionResult getDoctor()
        {
            return Ok(doctorService.GetAll());
        }
    }
}
