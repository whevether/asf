using System;

namespace ASF.Domain.Entities
{
    /// <summary>
    /// 字典表
    /// </summary>
    public class AsfDictionary: Entity<long>
    {
        /// <summary>
        /// 字典名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字典编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 租户id
        /// </summary>
        public long? TenancyId { get; set; }
        /// <summary>
        /// 字典Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 字典扩充字段
        /// </summary>
        public string Options { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}