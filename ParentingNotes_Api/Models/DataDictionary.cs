using SqlSugar;

namespace ParentingNotes_Api.Models
{
    /// <summary>
    /// 数据字典实体类
    /// </summary>
    [SugarTable("data_dictionary")]
    public class DataDictionary
    {
        /// <summary>
        /// 类目
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public string dic_name { set; get; }
        /// <summary>
        /// 值
        /// </summary>
        public string dic_values { set; get; }
    }
}
