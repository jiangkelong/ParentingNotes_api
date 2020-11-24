using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Models.ViewModels;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Interfaces
{
    /// <summary>
    /// 笔记,基本服务接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INoteBaseService<T> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<ApiResult<string>> AddAsync(T parm);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResult<T>> GetByIdAsync(int id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<ApiResult<NoteSummary>> ModifyAsync(T parm);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResult<string>> DeleteAsync(NoteDeleteRequestModel parm);
        /// <summary>
        /// 生成总结说明
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        NoteSummary CreateSummary(T parm);
    }
}
