using SqlSugar;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 宝宝实体类
    /// </summary>
    [SugarTable("baby")]
    public class Baby : BaseModel
    {
        /// <summary>
        /// 宝宝名称
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 性别
        /// </summary>
        public string gender { set; get; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string birthday { set; get; }
        /// <summary>
        /// 出生体重
        /// </summary>
        public decimal? birth_weight { set; get; }
        /// <summary>
        /// 出生体长
        /// </summary>
        public decimal? birth_height { set; get; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string avatar_url { set; get; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public int founder_id { set; get; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string updatedOn { get; set; }
    }
}
