using Newtonsoft.Json;
using System;

namespace erdus.ng.DTO
{
    public class EditResponsibilityDTO
    {
        [JsonProperty("newUserGuid")]
        public Guid NewUserGuid { get; set; }
    }
}
