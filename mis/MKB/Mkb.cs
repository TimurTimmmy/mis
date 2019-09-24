using Newtonsoft.Json;
using System.Collections.Generic;

namespace mis.MKB
{
    public class Mkb10
    {
        [JsonProperty("МКБ-10")]
        public List<Mkb> MkbList{ get; set; }
    }

    public partial class Mkb
    {
        [JsonProperty("Код диагноза")]
        public string Code { get; set; }

        [JsonProperty("Название диагноза")]
        public string Name { get; set; }

        [JsonProperty("Код родителя", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentCode { get; set; }
    }
}
