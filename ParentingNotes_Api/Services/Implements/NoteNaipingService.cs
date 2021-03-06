﻿using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Implements
{
    public class NoteNaipingService:NoteBaseService<NoteNaiping>,INoteNaipingService
    {
        /// <summary>
        /// 重写
        /// 生成总结说明
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public override NoteSummary CreateSummary(NoteNaiping parm)
        {
            NoteSummary sy = new NoteSummary
            {
                note_category = "naiping",
                note_id = parm.id,
                baby_id = parm.baby_id,
                user_id = parm.user_id,
                note_time = parm.note_time,
                note_date = parm.note_time.Substring(0, 10),
                updatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                finished = true
            };
            sy.summary = $"摄入 {parm.intake} ml {parm.kind}。";
            return sy;
        }
    }
}
