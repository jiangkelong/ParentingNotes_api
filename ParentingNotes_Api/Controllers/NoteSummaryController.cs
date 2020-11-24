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
    public class NoteSummaryController : ControllerBase
    {
        private readonly INoteSummaryService _noteSummaryService;
        public NoteSummaryController(INoteSummaryService noteSummaryService)
        {
            _noteSummaryService = noteSummaryService;
        }
        public async Task<IActionResult> getHistoryList(HistoryNotesRequestModel parm)
        {
            var res = await _noteSummaryService.GetHistoryPageList(parm);
            return Ok(res);
        }
        public async Task<IActionResult> getTodayList(int baby_id)
        {
            var res = await _noteSummaryService.GetTodayList(baby_id);
            return Ok(res);
        }
    }
}