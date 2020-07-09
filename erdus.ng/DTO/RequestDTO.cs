using erdus.ng.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string ResponsiblePerson { get; set; }
        public bool HasResponsiblePerson { get; set; }
        public string Topic { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }     
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
