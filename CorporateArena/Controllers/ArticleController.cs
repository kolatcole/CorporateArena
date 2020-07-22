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
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SaveArticle")]
        public async Task<IActionResult> SaveArticle(Article data)
        {
            var result = await _service.SaveArticleAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetArticle/{ID}")]
        public async Task<IActionResult> GetArticle(int ID)
        {
            var result = await _service.GetArticleWithCommentsAsync(ID);
            return Ok(result);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("LikeArticle")]
        public async Task<IActionResult> LikeArticle(ArticleLikeViewModel data)
        {
            var result = await _service.LikeArticleAsync(data.UserID, data.ArticleID);
            return Ok(result);
        }
    }
}
