using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineAcademy.Model.StudentModels
{
   public class SignInStudentModel
    {
        [Required, EmailAddress]
        public String Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}
