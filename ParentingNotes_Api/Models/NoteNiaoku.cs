using SqlSugar;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 笔记-换尿裤
    /// </summary>
    [SugarTable("note_niaoku")]
    public class NoteNiaoku : BaseNote
    {
        /// <summary>
        /// 尿裤状态
        /// </summary>
        public string status { set; get; }
    }
}
