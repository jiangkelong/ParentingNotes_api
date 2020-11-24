using ParentingNotes_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 通过openid查询用户是否存在
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        Task<bool> existAsync(string openid);
        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<User> AddAsync(User parm);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<string> ModifyAsync(User parm);
        Task<User> GetByOpenIdAsync(string openid);
    }
}
