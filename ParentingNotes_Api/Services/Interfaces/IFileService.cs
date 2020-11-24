using Microsoft.AspNetCore.Http;
using ParentingNotes_Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="file"></param>
        /// <returns>头像服务器地址</returns>
        Task<ApiResult<string>> UploadAvatar(IFormFile file);
    }
}
