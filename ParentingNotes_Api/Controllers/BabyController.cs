using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParentingNotes_Api.Models.ViewModels;
using ParentingNotes_Api.Services.Interfaces;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BabyController : ControllerBase
    {
        private readonly IBabyService _babyService;
        public BabyController(IBabyService babyService)
        {
            _babyService = babyService;
        }
        public async Task<IActionResult> addBaby(EditBabyViewModel parm)
        {
            var res = await _babyService.AddAsync(parm);
            return Ok(res);
        }
        public async Task<IActionResult> modifyBaby(EditBabyViewModel parm)
        {
            var res = await _babyService.ModifyAsync(parm);
            return Ok(res);
        }
        public async Task<IActionResult> getBaby(int id)
        {
            var res = await _babyService.GetById(id);
            return Ok(res);
        }
        public async Task<IActionResult> getBabyList()
        {
            var res = await _babyService.GetListByUser();
            return Ok(res);
        }
    }
}