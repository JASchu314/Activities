 using System;
using System.ComponentModel.DataAnnotations;
 
 namespace retake.Models{
    public class loginViewModel : BaseEntity{
 
 [Required(ErrorMessage = "Please enter an E-mail")]
        [EmailAddress(ErrorMessage="Please enter a valid E-mail address")]
        [Display(Name = "E-mail:")]
        public string Email {get; set;}
        
        [Required(ErrorMessage = "Please enter a password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password {get; set;}

    }
 }