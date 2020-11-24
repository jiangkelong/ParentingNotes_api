using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Services.Interfaces;
using System;

namespace ParentingNotes_Api.Services.Implements
{
    public class NoteWanshuaService : NoteBaseService<NoteWanshua>, INoteWanshuaService
    {
        /// <summary>
        /// 重写
        /// 生成总结说明
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public override NoteSummary CreateSummary(NoteWanshua parm)
        {
            NoteSummary sy = new NoteSummary
            {
                note_category = "wanshua",
                note_id = parm.id,
                baby_id = parm.baby_id,
                user_id = parm.user_id,
                note_time = parm.note_time,
                note_date = parm.note_time.Substring(0, 10),
                updatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                finished = true
            };

            sy.summary = $"玩了{Utils.TwoTimeInterval(parm.begin_time, parm.end_time)}。";
            return sy;
        }
    }
}
