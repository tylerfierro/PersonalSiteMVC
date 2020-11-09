using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PersonalSiteMVC.Models
{
    public class ContactViewModel
    {

        [Required(ErrorMessage = "* A name is required.")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Subject { get; set; }

        [Required(ErrorMessage = "* A message is required.")]
        [UIHint("MultilineText")]
        public string Message { get; set; }

    }
}