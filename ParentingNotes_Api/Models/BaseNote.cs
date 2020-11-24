using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models
{
    public class BaseNote
    {
        /// <summary>
        /// 自增id
        /// </summary>
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int id { get; set; }
        /// <summary>
        /// 宝宝id
        /// </summary>
        public int baby_id { set; get; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int? user_id { set; get; }
        /// <summary>
        /// 笔记时间
        /// </summary>
        public string note_time { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string memo { set; get; }
        /// <summary>
        /// 插入时间
        /// </summary>
        public string createdOn { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string updatedOn { get; set; }
        /// <summary>
        /// 当前用户是否可以编辑或删除(ORM在查询、增加、删除、更新时会过滤这一列)
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public bool canEdit { set; get; }
    }
}
