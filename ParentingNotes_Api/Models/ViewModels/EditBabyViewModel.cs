using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Models.ViewModels
{
    /// <summary>
    /// 宝宝信息编辑实体
    /// </summary>
    public class EditBabyViewModel : Baby
    {
        public string identity { set; get; }
    }
}
