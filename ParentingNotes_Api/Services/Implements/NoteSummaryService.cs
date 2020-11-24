using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Models.ViewModels;
using ParentingNotes_Api.Services.Interfaces;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Implements
{
    public class NoteSummaryService : DbContext, INoteSummaryService
    {
        public async Task<ApiResult<List<NoteSummary>>> GetHistoryPageList(HistoryNotesRequestModel parm)
        {
            var res = new ApiResult<List<NoteSummary>>();
            try
            {
                var today = DateTime.Now.ToString("yyyy-MM-dd");
                var list = await Db.Queryable<NoteSummary>()
                    .Where(it => it.baby_id == parm.baby_id && !it.note_date.Equals(today))
                    .OrderBy(it => it.note_time, OrderByType.Desc)
                    .ToPageListAsync(parm.page_index, parm.page_size);
                var time = "";
                for (int i = 0; i < list.Count; i++)
                {
                    time = list[i].note_time;
                    list[i].note_time = time.Substring(11);
                }

                res.data = list;
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error + ex.Message;
            }
            return res;
        }

        public async Task<ApiResult<List<NoteSummary>>> GetTodayList(int babyId)
        {
            var res = new ApiResult<List<NoteSummary>>();
            try
            {
                var today = DateTime.Now.ToString("yyyy-MM-dd");

                var list = await Db.Queryable<NoteSummary>()
                    .Where(it => it.baby_id == babyId && it.note_date.Equals(today))
                    .OrderBy(it => it.note_time, OrderByType.Desc)
                    .OrderBy(it => it.id, OrderByType.Desc)
                    .ToListAsync();
                var time = "";
                for (int i = 0; i < list.Count; i++)
                {
                    time = list[i].note_time;
                    list[i].note_time = time.Substring(11);
                }
                res.data = list;
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error + ex.Message;
            }
            return res;
        }
    }
}
