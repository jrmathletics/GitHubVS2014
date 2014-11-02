using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Oblig1;

namespace Oblig1.Model
{
    public class User
    {
        [Key]
        public int userid { get; set; }

        [Required(ErrorMessage = "Firstname must be added")]
        [StringLength(50, ErrorMessage = "Maximum 50 charactes in firstname")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Surname must be added")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters in surname")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Address must be added")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters in address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Postnr må oppgis")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Postnr må være 4 siffer")]
        public string postcode { get; set; }

        [Required(ErrorMessage = "Poststed må oppgis")]
        public string city { get; set; }

        [Required(ErrorMessage = "E-mail must be added")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Phonenr must be added")]
        [StringLength(20, ErrorMessage = "Maximum 20 characters in phonenr")]
        public string phonenr { get; set; }

        [Required(ErrorMessage = "Password must be added")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Minimum 6 characters in password, maximum 25")]
        public string password { get; set; }
    }
}
