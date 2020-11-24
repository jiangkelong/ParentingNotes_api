using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models
{
    public class BaseModel
    {
        /// <summary>
        /// 自增id
        /// </summary>
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int id { get; set; }
        /// <summary>
        /// 插入时间
        /// </summary>
        public string createdOn { get; set; }
    }
}
