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
    public class NoteNaipingController : ControllerBase
    {
        private readonly INoteNaipingService _noteService;
        public NoteNaipingController(INoteNaipingService noteService)
        {
            _noteService = noteService;
        }
        public async Task<IActionResult> add(NoteNaiping parm)
        {
            var res = await _noteService.AddAsync(parm);
            return Ok(res);
        }
        public async Task<IActionResult> modify(NoteNaiping parm)
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