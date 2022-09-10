using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using RestAPI.ModelViews;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private apitestContext _apitestContext;
        public UserController(apitestContext apitestContext)
        {
            _apitestContext = apitestContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRegistrationModel userReg)
        {
            var user = _apitestContext.Users.FirstOrDefault(a => a.Email
                .Equals(userReg.Email,StringComparison
                    .InvariantCultureIgnoreCase));
            if (user != null)
            {
                return BadRequest("User Already Exist");
            }

            user = _apitestContext.Users.Add(new User
            {
                FirstName = userReg.FirstName,
                LastName = userReg.LastName,
                Email = userReg.Email,
                Password = userReg.Password
            }).Entity;

            _apitestContext.SaveChanges();

            return Ok(user);
        }
    }
}
