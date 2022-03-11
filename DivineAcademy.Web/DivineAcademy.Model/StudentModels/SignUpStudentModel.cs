using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineAcademy.Model.StudentModels
{
   public class SignUpStudentModel
    {

        [Required(ErrorMessage = "Please Enter Your Full Name")]
        [Display(Name = "Full Name")]
        public String FullName { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please Enter Phone Number")]
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please Enter Your Email Address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public String Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please Enter Strong Password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password Does Not Match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public String Password { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;



        [Required(ErrorMessage = "Please Enter Your Address")]
        [Display(Name = "Address")]
        public String Address { get; set; } = string.Empty;
    }
}
