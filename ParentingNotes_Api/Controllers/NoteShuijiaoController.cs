using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Models.ViewModels;
using ParentingNotes_Api.Services.Interfaces;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class NoteShuijiaoController : ControllerBase
    {
        private readonly INoteShuijiaoService _noteService;
        public NoteShuijiaoController(INoteShuijiaoService noteService)
        {
            _noteService = noteService;
        }
        public async Task<IActionResult> add(NoteShuijiao parm)
        {
            var res = await _noteService.AddAsync(parm);
            return Ok(res);
        }
        public async Task<IActionResult> modify(NoteShuijiao parm)
        {
            var res = await _noteService.ModifyAsync(parm);
            return Ok(res);
        }
        public async Task<IActionResult> delete(NoteDeleteRequestModel parm)
        {
            var res = await _noteService.DeleteAsync(parm);
            return Ok(res);
        }
        public async Task<IActionResult> get(int id)
        {
            var res = await _noteService.GetByIdAsync(id);
            return Ok(res);
        }
    }
}