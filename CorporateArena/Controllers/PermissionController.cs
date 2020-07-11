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
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _service;
        public PermissionController(IPermissionService service)
        {
            _service = service;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetUserByID/{ID}")]
        public async Task<IActionResult> GetUserByID(int ID)
        {
            var result = await _service.GetUserWithRole(ID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpPost("AssignRoleToUser/{roleID}/{userID}")]
        public async Task<IActionResult> AssignRoleToUser(int roleID,int userID)
        {
            var result = await _service.AssignRoletoUser(roleID, userID);
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
            var result = await _service.AssignPrivilegetoRole(roleID, privilegeID);
            return Ok(result);
        }
    }
}
