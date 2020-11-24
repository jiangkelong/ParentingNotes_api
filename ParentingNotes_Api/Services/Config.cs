using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace ParentingNotes_Api.Services
{
    public static class Config
    {
        /// <summary>
        /// 为了获取上下文HttpContext
        /// 先在startup.cs ConfigureServices中注册
        /// 再在startup.cs Configure中为该属性指定
        /// 这样在程序中就能获取到HttpContextAccessor，并用来访问HttpContext
        /// </summary>
        public static IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// 为了获取虚拟路径
        /// </summary>
        public static IHostingEnvironment _iHostingEnvironment;

        public static string host = "http://localhost:64089/";
        /// <summary>
        /// 从请求头token中获取userId
        /// </summary>
        public static int userid()
        {
            var auth = _httpContextAccessor.HttpContext.AuthenticateAsync().Result.Principal.Claims;
            var userId = auth.FirstOrDefault(t => t.Type.Equals("userId"))?.Value;

            return userId == null ? 0 : Convert.ToInt32(userId);
        }
    }
}
