namespace ASF.Application.DTO.AsfDictionary
{
    /// <summary>
    /// 修改字典
    /// </summary>
    public class AsfDictionaryModifyRequestDto:AsfDictionaryCreateRequestDto
    {
        /// <summary>
        /// 字典ID
        /// </summary>
        public string Id { get; set; }
    }
}