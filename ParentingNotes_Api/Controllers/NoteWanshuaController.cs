using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Models.ViewModels;
using ParentingNotes_Api.Services.Interfaces;

namespace ParentingNotes_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class NoteWanshuaController : ControllerBase
    {
        private readonly INoteWanshuaService _noteService;
        public NoteWanshuaController(INoteWanshuaService noteService)
        {
            _noteService = noteService;
        }
        public async Task<IActionResult> add(NoteWanshua parm)
        {
            var res = await _noteService.AddAsync(parm);
            return Ok(res);
        }
        public async Task<IActionResult> modify(NoteWanshua parm)
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