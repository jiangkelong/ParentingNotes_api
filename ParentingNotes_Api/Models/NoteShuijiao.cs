using SqlSugar;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 笔记-睡觉
    /// </summary>
    [SugarTable("note_shuijiao")]
    public class NoteShuijiao : BaseNote
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
