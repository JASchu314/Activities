using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace retake.Models{
    public class ActivityModelViewModel : BaseEntity{
   [Required(ErrorMessage="Title is required")]
   [MinLength(2, ErrorMessage="Title must be at least two characters")]
      public string Title { get; set; }
       public TimeSpan Time {get; set;}
         [CurrentDate(ErrorMessage="Date cannot be in the past!")]
        public DateTime Date{get; set;}
        public int DurationLength {get; set;}
        public string DurationString {get; set;}

      [Required(ErrorMessage="Please enter a Description")]
      [MinLength(10, ErrorMessage="Description must be at least 10 characters")]
        public string description {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public int UserId {get; set;}
                   
     public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if(dt > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    } 
   
    }
}