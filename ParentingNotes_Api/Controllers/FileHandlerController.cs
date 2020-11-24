using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParentingNotes_Api.Services.Interfaces;

namespace ParentingNotes_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileHandlerController : ControllerBase
    {
        private readonly IFileService _iFileService;
        public FileHandlerController(IFileService fileService)
        {
            _iFileService = fileService;
        }
        [HttpPost]
        public async Task<IActionResult> UploadAvatar()
        {
            var file = Request.Form.Files["baby_avatar"]; //对应小程序 name
            var res = await _iFileService.UploadAvatar(file);
            return Ok(res);
        }
    }
}