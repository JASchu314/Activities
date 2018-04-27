using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace retake.Models{
    public class Joiner : BaseEntity{
        [Key]
      public int JoinerId { get; set; }
      public int UserId {get; set;}
      public int ActivityId {get; set;}
      public User User {get; set;}
      public ActivityModel Activity {get; set;}
    }
}