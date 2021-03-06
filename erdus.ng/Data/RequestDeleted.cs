﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace erdus.ng.Data
{
    public class RequestDeleted
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public IdentityUser Requester { get; set; }

        [Required]
        [ForeignKey("Requester")]
        public string RequesterId { get; set; }

        public IdentityUser ResponsiblePerson { get; set; }

        [ForeignKey("ResponsiblePerson")]
        public string ResponsiblePersonId { get; set; }

        public string Topic { get; set; }

        public string Content { get; set; }

        public string Photo { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public Status RequestStatus { get; set; }

        [Required]
        [ForeignKey("RequestStatus")]
        public int RequestStatusId { get; set; }

        [Required]
        public Category RequestCategory { get; set; }

        [Required]
        [ForeignKey("RequestCategory")]
        public int RequestCategoryId { get; set; }

        public string Answer { get; set; }
    }
}
