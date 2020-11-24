using System;
using System.Threading.Tasks;
using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Services.Interfaces;

namespace ParentingNotes_Api.Services.Implements
{
    public class UserService : DbContext, IUserService
    {
        public async Task<User> AddAsync(User parm)
        {
            User u = new User();
            try
            {
                parm.createdOn = parm.updatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                u = await Db.Insertable(parm).ExecuteReturnEntityAsync();
            }
            catch
            {

            }
            return u;
        }

        public async Task<bool> existAsync(string openid)
        {
            return await Db.Queryable<User>().Where(it => it.openId == openid).AnyAsync();
        }

        public async Task<User> GetByOpenIdAsync(string openid)
        {
            User u = new User();
            try
            {
                u = await Db.Queryable<User>().Where(it => it.openId == openid).SingleAsync();
            }
            catch
            {

            }
            return u;
        }

        public async Task<string> ModifyAsync(User parm)
        {
            try
            {
                parm.updatedOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                await Db.Updateable(parm).WhereColumns(it => it.openId).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
            }
            catch
            {

            }
            return "";
        }
    }
}
