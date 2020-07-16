using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Services.Interfaces;

namespace ParentingNotes_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        /// <summary>
        /// 
        /// </summary>
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public string GetToken(User user)
        {
            var token = _tokenService.GetToken(user);
            var response = new
            {
                Status = true,
                Token = token,
                Type = "Bearer"
            };
            return token;
        }
    }
}