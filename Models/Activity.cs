using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace retake.Models{
    public class ActivityModel : BaseEntity{
        [Key]
      public int ActivityId { get; set; }
      public string Title { get; set; }
      public TimeSpan Time {get; set;}
      public DateTime Date{get; set;}
      public int DurationLength {get; set;}
      public string DurationString {get; set;}
      public string description {get; set;}
    public DateTime CreatedAt {get; set;}
      public DateTime UpdatedAt {get; set;}
      public int UserId {get; set;}

      public User User {get; set;}
      public List<Joiner> joiners {get; set;}
      public ActivityModel(){
          joiners = new List<Joiner>();
      }
    }
}