using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Assignment.Models
{

    // person model
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "First Name")] // update display name
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Address 1")]
        [Required]
        public string AddressOne { get; set; }

        [Display(Name = "Address 2")]
        public string AddressTwo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

    }
}
