using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Models.ViewModels;
using ParentingNotes_Api.Services.Interfaces;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Implements
{
    public class BabyService : DbContext, IBabyService
    {
        public async Task<ApiResult<string>> AddAsync(EditBabyViewModel parm)
        {
            var res = new ApiResult<string>();
            try
            {
                int user_id = Config.userid();
                Baby baby = parm as Baby;
                baby.founder_id = user_id;
                baby.createdOn = baby.updatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                baby.avatar_url = string.IsNullOrEmpty(baby.avatar_url) ? "uploads/default_baby-avatar.png" : baby.avatar_url;
                baby = await Db.Insertable(baby).ExecuteReturnEntityAsync();//插入宝宝表，返回实体

                var link = new BabyUser
                {
                    baby_id = baby.id,
                    user_id = user_id,
                    identity = parm.identity,
                    createdOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                await Db.Insertable(link).ExecuteCommandAsync();//插入宝宝-用户关联表
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error + ex.Message;
            }
            return res;
        }

        public async Task<ApiResult<EditBabyViewModel>> GetById(int id)
        {
            var res = new ApiResult<EditBabyViewModel>();
            try
            {
                int user_id = Config.userid();
                res.data = await Db.Queryable<Baby, BabyUser>((t1, t2) => new object[]
                {
                    JoinType.Inner,t1.id==t2.baby_id
                })
                .Where((t1, t2) => t1.id == id && t2.user_id == user_id)
                .Select((t1, t2) => new EditBabyViewModel
                {
                    id = t1.id,
                    name = t1.name,
                    gender = t1.gender,
                    birthday = t1.birthday,
                    birth_weight = t1.birth_weight,
                    birth_height = t1.birth_height,
                    avatar_url = t1.avatar_url,
                    founder_id = t1.founder_id,
                    identity = t2.identity

                }).SingleAsync();
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error + ex.Message;
            }
            return res;
        }

        public async Task<ApiResult<List<Baby>>> GetListByUser()
        {
            var res = new ApiResult<List<Baby>>();
            try
            {
                int user_id = Config.userid();
                res.data = await Db.Queryable<BabyUser, Baby>((t1, t2) => new object[]
                      {
                        JoinType.Inner,t1.baby_id == t2.id
                      })
                    .Where((t1, t2) => t1.user_id == user_id)
                    .Select((t1, t2) => new Baby
                    {
                        id = t2.id,
                        name = t2.name,
                        birthday = t2.birthday,
                        avatar_url = t2.avatar_url
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error + ex.Message;
            }
            return res;
        }

        public async Task<ApiResult<string>> ModifyAsync(EditBabyViewModel parm)
        {
            var res = new ApiResult<string>();
            try
            {
                int user_id = Config.userid();
                Baby baby = parm as Baby;
                baby.updatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //更新宝宝信息
                await Db.Updateable(baby).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
                //更新用户级联表
                await Db.Updateable<BabyUser>().SetColumns(it => new BabyUser() { identity = parm.identity })
                    .Where(it => it.baby_id == parm.id && it.user_id == user_id).ExecuteCommandAsync();
            }
            catch (Exception ex)
            {
                res.statusCode = (int)ApiEnum.Error;
                res.message = ApiEnum.Error + ex.Message;
            }
            return res;
        }
    }
}
