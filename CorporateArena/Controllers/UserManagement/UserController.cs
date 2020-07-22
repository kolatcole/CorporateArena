﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _service;

        public UserController(IUserService service)
        {

            _service = service;
        }


        /// <summary>
        /// A new user requires approval from a super admin 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("RegisterNewUser")]
        public async Task<IActionResult> RegisterNewUser(User data)
        {

            var result = await _service.RegisterUserAsync(data);
            return Ok(result);

        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(AuthWithPasswordViewModel data)
        {
            var result = await _service.LoginAsync(data.username, data.password);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("AuthenticateWithToken")]
        public async Task<IActionResult> AuthenticateWithToken(AuthWithTokenViewModel data)
        {
            var result = await _service.LoginWithTokenAsync(data.Token);
            return Ok(result);
        }

        /// <summary>
        /// Pass in the user ID that requires approval
        /// If successful, the method returns true
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost("Activate/{ID}")]
        public async Task<IActionResult> Activate(int ID)
        {
            var result = await _service.ApproveUserAsync(ID);
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        
        [HttpGet("GetAllUsers")]
      //  [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _service.GetAllUsersAsync();
            return Ok(result);
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetUserByID/{ID}")]
        public async Task<IActionResult> GetUserByID(int ID)
        {
            var result = await _service.GetUserWithRoleAsync(ID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpPost("AssignRoleToUser/{roleID}/{userID}")]
        public async Task<IActionResult> AssignRoleToUser(int roleID, int userID)
        {
            var result = await _service.AssignRoletoUserAsync(roleID, userID);
            return Ok(result);
        }
    }
}
