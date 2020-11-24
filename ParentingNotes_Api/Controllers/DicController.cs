using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParentingNotes_Api.Services.Interfaces;

namespace ParentingNotes_Api.Controllers
{
    /// <summary>
    /// 数据字典
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class DicController : ControllerBase
    {
        private readonly IDataDictionaryService _service;
        public DicController(IDataDictionaryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> getItems(string item_name)
        {
            var res = await _service.getItemsAsync(item_name);
            return Ok(res);
        }
    }
}