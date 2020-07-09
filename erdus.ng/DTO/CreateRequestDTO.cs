using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.DTO
{
    public class CreateRequestDTO
    {      
        public string Topic { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string CategoryId { get; set; }
    }
}
