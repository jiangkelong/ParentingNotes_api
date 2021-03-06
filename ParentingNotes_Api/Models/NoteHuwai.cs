﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 笔记-户外
    /// </summary>
    [SugarTable("note_huwai")]
    public class NoteHuwai : BaseNote
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public string begin_time { set; get; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string end_time { set; get; }
    }
}
