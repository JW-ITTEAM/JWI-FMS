
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FMS_API.Controllers
{    
    public class AccountController : BaseApiController
    {
        private readonly IRepository<T_USER> _accountRepository;
        private readonly IMapper _mapper;

        public AccountController (IRepository<T_USER> accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/Login")]
        [Authorize]
        public async Task<IActionResult> LoginAsync()
        {
            return Ok();
        }

        [HttpGet]
        [Route("getDbCurrentUser")]
        [Authorize]
        public async Task<IActionResult> getCurrentUserAsync(string userEmail)
        {            
            var currentUser = await _accountRepository.GetFirstOrDefaultAsync(x => x.F_UserEmail == userEmail);
            if (currentUser == null)
            {
                return Ok(null);
            }
            var result = _mapper.Map<VM_USER>(currentUser);
            return Ok(result);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUpAsync(VM_USER user)
        {
            if (user == null || user.F_UserEmail == null)
            {
                return BadRequest();                
            }

            var query = "select * from T_User where F_UserEmail = @useremail";
            var result = await _accountRepository.GetWithRawSqlAsync(query, new SqlParameter("@useremail", user.F_UserEmail));

            if (result.Count() > 0)
            {
                return Ok("This user is already registered in Db.");
            }

            await _accountRepository.InsertAsync(new T_USER
            {
                F_UserId = "test",
                F_UserPwd = null,
                F_UserName = user.F_UserName,
                F_UserEmail = user.F_UserEmail,
                F_Phone = user.F_Phone,
                F_FAX = user.F_FAX,
                F_Level = 0,
                F_Dept = user.F_Dept,
                F_CompanyId = 0,
                F_Status = 1,                
                F_CreateTime = DateTime.Now,
                F_CreateBy = null,
                F_UpdateTime = DateTime.Now,
                F_UpdateBy = null
            });

            await _accountRepository.Save();
            return Ok(true);
        }
    }
}
