
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS_API.Controllers
{    
    public class AccountController : BaseApiController
    {

        [HttpGet]
        [Route("/Login")]
        [Authorize]
        public async Task<IActionResult> LoginAsync()
        {
            return Ok();
        }
    }
}
