using SqlSugar;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 笔记-奶瓶
    /// </summary>
    [SugarTable("note_naiping")]
    public class NoteNaiping:BaseNote
    {
        /// <summary>
        /// 喂食种类
        /// </summary>
        public string kind { set; get; }
        /// <summary>
        /// 摄入量
        /// </summary>
        public decimal intake { set; get; }
    }
}
