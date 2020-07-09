using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.DTO
{
    public class EditRequestStatusDTO
    {
        [JsonProperty("newStatusId")]
        public int NewStatusId { get; set; }

        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
}
