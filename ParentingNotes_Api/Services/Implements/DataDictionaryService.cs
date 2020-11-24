using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Implements
{
    public class DataDictionaryService : DbContext, IDataDictionaryService
    {
        public async Task<ApiResult<List<string>>> getItemsAsync(string item_name)
        {
            var res = new ApiResult<List<string>>();
            try
            {
                var values = await Db.Queryable<DataDictionary>()
                    .Where(it => it.dic_name == item_name)
                    .Select(it => it.dic_values).SingleAsync();
                if (!string.IsNullOrEmpty(values))
                {
                    values = values.Replace('，', ',');
                    res.data = Utils.StrToListString(values);
                }
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
