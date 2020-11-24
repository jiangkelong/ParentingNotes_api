using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models.ViewModels
{
    /// <summary>
    /// 历史笔记请求参数类
    /// </summary>
    public class HistoryNotesRequestModel
    {
        /// <summary>
        /// 宝宝id
        /// </summary>
        public int baby_id { set; get; }
        /// <summary>
        /// 第几页数据
        /// </summary>
        public int page_index { set; get; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int page_size { set; get; } = 20;
    }
}
