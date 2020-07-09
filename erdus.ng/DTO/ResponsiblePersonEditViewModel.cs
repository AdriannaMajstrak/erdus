using erdus.ng.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.DTO
{
    public class ResponsiblePersonEditViewModel
    {
        public int Id { get; set; }

        public string Photo { get; set; }

        [DisplayName("Zgłaszający")]
        public string Requester { get; set; }
        
        [DisplayName("Temat")]
        public string Topic { get; set; }

        [DisplayName("Lokalizacja GPS")]
        public string Location { get; set; }

        [DisplayName("Adres")]
        public string Address { get; set; }

        [DisplayName("Data utworzenia")]
        public DateTime CreationDate { get; set; }

        [DisplayName("Opis")]
        public string Content { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public List<IdentityUser> ListOfResponsiblePersons;

        [DisplayName("Osoba odpowiedzialna")]
        [Required(ErrorMessage = "Wskaż osobę odpowiedzialną")]
        public string ResponsiblePersonId { get; set; }
        //public IdentityUser ResponsiblePerson { get; set; }

        [DisplayName("Status zgłoszenia")]
        public string Status { get; set; }

    }
}
