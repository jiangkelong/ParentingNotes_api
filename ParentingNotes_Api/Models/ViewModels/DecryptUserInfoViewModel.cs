using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models.ViewModels
{
    public class DecryptUserInfoViewModel
    {
        /// <summary>
        /// 前端调用wx.login返回的code
        /// </summary>
        public string code { set; get; }
        /// <summary>
        /// 加密的用户敏感信息
        /// </summary>
        public string encryptedData { set; get; }
        /// <summary>
        /// 初始向量
        /// </summary>
        public string iv { set; get; }
        /// <summary>
        /// 微信昵称
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 微信头像url
        /// </summary>
        public string avatarUrl { get; set; }
    }
}
