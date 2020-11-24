using SqlSugar;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    [SugarTable("user")]
    public class User : BaseModel
    {
        /// <summary>
        /// 微信标识符
        /// </summary>
        public string openId { get; set; }
        /// <summary>
        /// 微信平台唯一标识符
        /// </summary>
        public string unionId { get; set; }
        /// <summary>
        /// 微信昵称
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 微信头像url
        /// </summary>
        public string avatarUrl { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string updatedOn { get; set; }
    }
}
