using ParentingNotes_Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Interfaces
{
    public interface IDataDictionaryService
    {
        Task<ApiResult<List<string>>> getItemsAsync(string item_name);
    }
}
