using KalyanJewellersDemo.IServices;
using KalyanJewellersDemo.Models;
using KalyanJewellersDemo.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KalyanJewellersDemo.Controllers.SignUp
{
    [Route("KalyanJewellers")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private ISignUpService signUpService { get; set; }

        public SignUpController(ISignUpService service, IWebHostEnvironment env)
        {
            signUpService = service;
            _env = env;
        }
        [HttpGet("Users")]
        public IActionResult getAllUsers()
        {
            try
            {
                return Ok(signUpService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("User/{id}")]
        public IActionResult getAnUser(int id)
        {
            try
            {
                return Ok(signUpService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("SignUp")]
        public IActionResult postUser(User user)
        {
            try
            {
                return Ok(signUpService.Add(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        [HttpPut("edit/{id}")]
        public IActionResult putUser(int id, User user)
        {
            try
            {
                var anUser = signUpService.GetById(id);
                return Ok(signUpService.Put(anUser, user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult deleteUser(int id)
        {
            try
            {
                var anUser = signUpService.GetById(id);
                return Ok(signUpService.Delete(anUser));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

    }
}
