using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models.ViewModels
{
    /// <summary>
    /// 登录成功返回给小程序
    /// </summary>
    public class WeXinLoginReponseViewModel
    {
        public string openId { set; get; }
        public string token { set; get; }
    }
}
