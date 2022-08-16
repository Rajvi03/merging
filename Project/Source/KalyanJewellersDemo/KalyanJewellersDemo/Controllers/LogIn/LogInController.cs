using KalyanJewellersDemo.Authentication;
using KalyanJewellersDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalyanJewellersDemo.Controllers.SignIn
{
    [Authorize]
    [Route("KalyanJewellers")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        

        private readonly IAuthenticationManager JWTAuthenticationManager;

        public LogInController(IAuthenticationManager AuthenticationManager)
        {
            this.JWTAuthenticationManager = AuthenticationManager;
        }
        [AllowAnonymous]
        [HttpPost("SignIn")]
        public IActionResult Authenticate([FromBody] UserVM userVM)
        {
            try
            {
                var token = JWTAuthenticationManager.Authenticate(userVM.Email, userVM.Password);

                if (token == null)
                    return Unauthorized();

                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
