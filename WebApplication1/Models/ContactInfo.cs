using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplication1.ValidationCustom;

namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "Navn er påkrevd")]
        [Display(Name = "Navn")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must be from 3 to 20 symbols")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email er påkrevd")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid email")]

        public string Email { get; set; }

        [Display(Name = "Tema")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Beskjeden er påkrevd")]
        [Display(Name = "Beskjed")]
        public string Message { get; set; }
    }
}