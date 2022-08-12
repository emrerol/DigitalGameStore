using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalGameStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime SignUpDate { get; set; }

        public string Country { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return Name + ' ' + Surname;
            }
        }

        public Gender Gender;

    }
    public enum Gender
    {
        Man,
        Woman
    }
}

