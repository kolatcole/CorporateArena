using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Schema;

namespace CorporateArena.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrainTeaserController : ControllerBase
    {
        private readonly IBrainTeaserService _service;
        public BrainTeaserController(IBrainTeaserService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("CreateBrainTeaser")]
        public async Task<IActionResult> CreateBrainTeaser(BrainTeaser data)
        {
            var result = await _service.SaveBrainTeaserAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetBrainTeaserAndAnswer/{ID}")]
        public async Task<IActionResult> GetBrainTeaserAndAnswer(int ID)
        {
            var result = await _service.GetBrainTeaserandAnswerAsync(ID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("AnswerBrainTeaser")]
        public async Task<IActionResult> AnswerBrainTeaser(BrainTeaserAnswer data)
        {
            var result = await _service.SubmitAnswerAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("UpdateBrainTeaser")]
        public async Task<IActionResult> UpdateBrainTeaser(BrainTeaser data)
        {
            var result = await _service.UpdateBrainTeaserAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("DeleteBrainTeaser/{userID}/{ID}")]
        public async Task<IActionResult> DeleteBrainTeaser(int userID, int ID)
        {
            var result = await _service.DeleteBrainTeaser(ID, userID);
            return Ok(result);
        }

    }
}
