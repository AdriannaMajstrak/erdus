using erdus.ng.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.DTO
{
    public class RequestDetailsDTO
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Requester { get; set; }
        public string ResponsiblePersonName { get; set; }
        public Guid? ResponsiblePersonGuid { get; set; }
        public string Topic { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public UsersRequestsPermissions UserPermissions { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Answer { get; set; }
    }

}
