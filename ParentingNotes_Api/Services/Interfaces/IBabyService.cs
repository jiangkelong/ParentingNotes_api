using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Interfaces
{
    public interface IBabyService
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<ApiResult<string>> AddAsync(EditBabyViewModel parm);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<ApiResult<string>> ModifyAsync(EditBabyViewModel parm);
        Task<ApiResult<EditBabyViewModel>> GetById(int id);
        Task<ApiResult<List<Baby>>> GetListByUser();
    }
}
