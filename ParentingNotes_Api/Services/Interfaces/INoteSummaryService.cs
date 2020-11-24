using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Interfaces
{
    public interface INoteSummaryService
    {
        /// <summary>
        /// 根据宝宝id获取列表
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<List<NoteSummary>>> GetHistoryPageList(HistoryNotesRequestModel parm);
        /// <summary>
        /// 根据宝宝id获取今日列表
        /// </summary>
        /// <param name="babyId"></param>
        /// <returns></returns>
        Task<ApiResult<List<NoteSummary>>> GetTodayList(int babyId);
    }
}
