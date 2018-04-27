using System;
using System.ComponentModel.DataAnnotations;


namespace retake.Models{
    public class UserViewModel : BaseEntity{
        [Required(ErrorMessage = "Please enter your First Name")]
        [RegularExpression("^[a-zA-Z]+$")]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters!")]
        [Display(Name = "FirstName:")]
        public string FirstName {get; set;}
        [Required(ErrorMessage = "Please enter your Last Name")]
        [RegularExpression("^[a-zA-Z]+$")]
        [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters!")]
        [Display(Name = "LastName:")]
        public string LastName {get; set;}
        
        [Required(ErrorMessage = "Please enter an E-mail")]
        [EmailAddress(ErrorMessage="Please enter a valid E-mail address")]
        [Display(Name = "E-mail:")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Please enter a password")]
        [Compare("PasswordCheck", ErrorMessage = "Passwords must match!")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password {get; set;}
          
        [Required(ErrorMessage = "Please confirm password")]
        [Compare("Password", ErrorMessage = "Passwords must match!")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string PasswordCheck {get; set;}
    }
}