using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class EditUserViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [MinLength(7, ErrorMessage = "Hasło musi mieć min. 7 znaków")]
        [Display(Name = "Hasło"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Wiek"), DataType(DataType.Text)]
        public int Age { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public IFormFile MyFile { get; set; }
    }
}
