using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 笔记-小结
    /// </summary>
    [SugarTable("note_summary")]
    public class NoteSummary :BaseModel
    {
        /// <summary>
        /// 笔记类型
        /// </summary>
        public string note_category { set; get; }
        /// <summary>
        /// 笔记id
        /// </summary>
        public int note_id { set; get; }
        /// <summary>
        /// 宝宝id
        /// </summary>
        public int baby_id { set; get; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int? user_id { set; get; }
        /// <summary>
        /// 笔记日期
        /// </summary>
        public string note_date { set; get; }
        /// <summary>
        /// 笔记时间
        /// </summary>
        public string note_time { set; get; }
        /// <summary>
        /// 笔记总结
        /// </summary>
        public string summary { set; get; }
        /// <summary>
        /// 是否结束
        /// </summary>
        public bool finished { set; get; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string updatedOn { get; set; }
    }
}
