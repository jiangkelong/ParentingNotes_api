using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 宝宝-用户关联实体
    /// </summary>
    [SugarTable("baby_user")]
    public class BabyUser : BaseModel
    {
        public int baby_id { set; get; }
        public int user_id { set; get; }
        /// <summary>
        /// 用户对于宝宝的身份
        /// </summary>
        public string identity { set; get; }
    }
}
