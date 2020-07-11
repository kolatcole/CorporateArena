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
    public class PrivilegeController : ControllerBase
    {
        private readonly IRepo<Privilege> _repo;
        public PrivilegeController(IRepo<Privilege> repo)
        {

            _repo = repo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SavePrivilege")]
        public async Task<IActionResult> SavePrivilege(Privilege data)
        {
            var result = await _repo.insertAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPrivileges")]
        public async Task<IActionResult> GetAllPrivileges()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);

        }
    }
}
