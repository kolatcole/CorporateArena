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
        // for test

        private readonly IEmailSender _service;


        // for email test



        private readonly IPrivilegeRepo _repo;
        public PrivilegeController(IPrivilegeRepo repo, IEmailSender service)
        {
            _service = service;
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
            return Ok(new { message = "Successful", status = result });
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

        [HttpGet("GetModels")]
        public async Task<IActionResult> GetModels()
        {
            var result = await _repo.GetModelsAsync();
            return Ok(result);
        }
        [HttpGet("GetActions")]
        public async Task<IActionResult> GetActions()
        {
            // var result = await _repo.GetActionsAsync();
            Models mod = new Models();
            var result = mod.GetActions();
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail()
        {
           await _service.SendEmailAsync();
            return Ok();
        }
    }
}
