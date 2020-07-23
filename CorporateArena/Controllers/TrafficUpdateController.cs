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
    public class TrafficUpdateController : ControllerBase
    {

        private readonly ITrafficUpdateService _service;

        public TrafficUpdateController(ITrafficUpdateService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SaveTrafficUpdate")]
        public async Task<IActionResult> SaveTrafficUpdate(TrafficUpdate data)
        {
            var result = await _service.SaveTrafficUpdateAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetTrafficUpdate/{ID}")]
        public async Task<IActionResult> GetTrafficUpdate(int ID)
        {
            var result = await _service.GetTrafficUpdateWithComments(ID);
            return Ok(result);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("CommentOnTrafficUpdate")]
        public async Task<IActionResult> CommentOnTrafficUpdate(TrafficComment data)
        {
            var result = await _service.SaveTrafficUpdateCommentAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="UpdateTrafficID"></param>
        /// <returns></returns>
        [HttpDelete("DeleteTrafficUpdate/{UserID}/{UpdateTrafficID}")]
        public async Task<IActionResult> DeleteTrafficUpdate(int UserID, int UpdateTrafficID)
        {
            var result = await _service.DeleteArticleAsync(UpdateTrafficID, UserID);
            return Ok(result);
        }

    }
}
