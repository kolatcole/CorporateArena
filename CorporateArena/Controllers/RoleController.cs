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
        private readonly IRoleRepo _repo;
        public RoleController(IRoleRepo repo) 
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="privilegeID"></param>
        /// <returns></returns>
        [HttpPost("AssignPrivilegetoRole/{roleID}/{privilegeID}")]
        public async Task<IActionResult> AssignPrivilegetoRole(int roleID, int privilegeID)
        {
            var result = await _repo.AssignPrivilegetoRoleAsync(roleID, privilegeID);
            return Ok(result);
        }
    }
}
