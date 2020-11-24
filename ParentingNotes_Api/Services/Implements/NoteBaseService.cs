using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Models.ViewModels;
using ParentingNotes_Api.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Implements
{
    public class NoteBaseService<T> : DbContext, INoteBaseService<T> where T : BaseNote, new()
    {
        public async Task<ApiResult<string>> AddAsync(T parm)
        {
            var res = new ApiResult<string>();
            parm.createdOn = parm.updatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var asyncResult = Db.Ado.UseTranAsync(() =>
            {
                try
                {
                    parm.user_id = Config.userid();

                    var entity = Db.Insertable(parm).ExecuteReturnEntity();//插入所属分类笔记表

                    var summary = CreateSummary(entity);//生成总结说明
                    summary.createdOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    Db.Insertable(summary).ExecuteCommand();//插入笔记总结表
                }
                catch (Exception ex)
                {
                    res.statusCode = (int)ApiEnum.Error;
                    res.message = ApiEnum.Error + ex.Message;
                }
            });
            asyncResult.Wait();
            return await Task.Run(() => res);
        }

        public async Task<ApiResult<string>> DeleteAsync(NoteDeleteRequestModel parm)
        {
            var res = new ApiResult<string>();
            try
            {
                var asyncResult = Db.Ado.UseTranAsync(() =>
                {
                    Db.Deleteable<T>().Where(it => it.id == parm.note_id).ExecuteCommand();//删除所属分类笔记表

                    Db.Deleteable<NoteSummary>().Where(it => it.note_category == parm.note_category && it.note_id == parm.note_id).ExecuteCommand();//删除笔记总结表
                });
                asyncResult.Wait();
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error + ex.Message;
            }
            return await Task.Run(() => res);
        }

        public async Task<ApiResult<T>> GetByIdAsync(int id)
        {
            var res = new ApiResult<T>();
            try
            {
                var entity = await Db.Queryable<T>().InSingleAsync(id);

                entity.canEdit = entity.user_id == Config.userid() ? true : false;//是否有编辑权限

                entity.user_id = null;//用户id不返回给前端

                res.data = entity;
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error + ex.Message;
            }
            return res;
        }

        public async Task<ApiResult<NoteSummary>> ModifyAsync(T parm)
        {
            var res = new ApiResult<NoteSummary>();
            try
            {
                parm.user_id = Config.userid();
                parm.updatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                NoteSummary summary = new NoteSummary();
                var asyncResult = Db.Ado.UseTranAsync(() =>
                {
                    Db.Updateable(parm).ExecuteCommand();//更新所属分类笔记表

                    summary = CreateSummary(parm);//生成总结说明

                    Db.Updateable(summary).IgnoreColumns(ignoreAllNullColumns: true)
                    .Where(it => it.note_category == summary.note_category && it.note_id == summary.note_id).ExecuteCommand();//更新笔记总结表
                });
                asyncResult.Wait();

                var time = summary.note_time;
                summary.note_time = time.Substring(11);
                res.data = summary;
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error + ex.Message;
            }
            return await Task.Run(() => res);
        }
        /// <summary>
        /// 生成总结说明
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public virtual NoteSummary CreateSummary(T parm)
        {
            throw new NotImplementedException();
        }
    }
}
