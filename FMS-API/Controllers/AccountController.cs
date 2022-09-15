
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS_API.Controllers
{
    public class AccountController : BaseApiController
    {
        public AccountController(UserManager<T_USER> userManager)
        {
            
        }

        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> LoginAsync(VM_USER user)
        {
            if (user == null)
                return BadRequest();

            if (!user.F_EmailVerified)
            {

            }

            return Ok();
        }
    }
}
