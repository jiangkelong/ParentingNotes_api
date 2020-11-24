using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models.ViewModels
{
    /// <summary>
    /// 笔记删除请求类
    /// </summary>
    public class NoteDeleteRequestModel
    {
        /// <summary>
        /// 笔记类型
        /// </summary>
        public string note_category { set; get; }
        /// <summary>
        /// 笔记id
        /// </summary>
        public int note_id { set; get; }
    }
}
