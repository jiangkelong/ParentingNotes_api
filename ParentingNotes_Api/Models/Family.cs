using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 家庭实体类
    /// </summary>
    [SugarTable("family")]
    public class Family : BaseModel
    {
        public int admin_id { set; get; }
    }
}
