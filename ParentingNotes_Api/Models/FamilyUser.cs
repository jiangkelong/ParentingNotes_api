using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 家庭-用户关联类
    /// </summary>
    [SugarTable("family_user")]
    public class FamilyUser : BaseModel
    {
        public int family_id { set; get; }
        public int user_id { set; get; }
    }
}
