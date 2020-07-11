using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepo _repo;

        public UserController(IUserRepo repo)
        {

            _repo = repo;
        }


        /// <summary>
        /// A new user requires approval from a super admin 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("RegisterNewUser")]
        public async Task<IActionResult> RegisterNewUser(User data)
        {

            var result = await _repo.RegisterUser(data);
            return Ok(result);

        }

        /// <summary>
        /// Pass in the user ID that requires approval
        /// If successful, the method returns true
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost("Approve/{ID}")]
        public async Task<IActionResult> Approve(int ID)
        {
            var result = await _repo.ApproveUser(ID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _repo.GetAllUsers();
            return Ok(result);
        
        }

    }
}
