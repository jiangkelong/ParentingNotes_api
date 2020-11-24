using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 家庭-宝宝关联类
    /// </summary>
    [SugarTable("family_baby")]
    public class FamilyBaby : BaseModel
    {
        public int family_id { set; get; }
        public int baby_id { set; get; }
    }
}
