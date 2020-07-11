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
    public class RoleController : ControllerBase
    {
        private readonly IRepo<Role> _repo;
        public RoleController(IRepo<Role> repo) 
        {

            _repo = repo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SaveRole")]
        public async Task<IActionResult> SaveRole(Role data)
        {
            var result = await _repo.insertAsync(data);
            return Ok(result);
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetRoleByID/{ID}")]
        public async Task<IActionResult> GetRoleByID(int ID)
        {
            var result = await _repo.getAsync(ID);
            return Ok(result);

        }
    }
}
