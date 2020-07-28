using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.Presentation.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _service;

        public VacancyController(IVacancyService service)
        {
            _service = service;
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SaveVacancy")]
        public async Task<IActionResult> SaveVacancy(Vacancy data)
        {
            var result = await _service.SaveVacancyAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetVacancy/{ID}")]
        public async Task<IActionResult> GetVacancy(int ID)
        {
            var result = await _service.GetVacancyByIDAsync(ID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        [HttpGet("GetVacancyByMode/{mode}")]
        public async Task<IActionResult> GetVacancyByMode(string mode)
        {
            var result = await _service.GetVacancyByModeAsync(mode);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet("GetVacancyByTitle/{title}")]
        public async Task<IActionResult> GetVacancyByTitle(string title)
        {
            var result = await _service.GetVacancyByTitleAsync(title);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpGet("GetVacancyByLocation/{location}")]
        public async Task<IActionResult> GetVacancyByLocation(string location)
        {
            var result = await _service.GetVacancyByLocationAsync(location);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="industry"></param>
        /// <returns></returns>
        [HttpGet("GetVacancyByIndustry/{industry}")]
        public async Task<IActionResult> GetVacancyByIndustry(string industry)
        {
            var result = await _service.GetVacancyByIndustryAsync(industry);
            return Ok(result);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="VacancyID"></param>
        /// <returns></returns>
        [HttpDelete("DeleteVacancy/{UserID}/{VacancyID}")]
        public async Task<IActionResult> DeleteVacancy(int UserID, int VacancyID)
        {
            var result = await _service.DeleteVacancyAsync(VacancyID, UserID);
            return Ok(result);
        }
    }
}
