using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParentingNotes_Api.Services.Interfaces;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SrcController : ControllerBase
    {
        private readonly IBabyService _babyService;
        public SrcController(IBabyService babyService)
        {
            _babyService = babyService;
        }
        public async Task<IActionResult> getBabyList()
        {
            var res = await _babyService.GetListByUser();
            return Ok(res);
        }
    }
}