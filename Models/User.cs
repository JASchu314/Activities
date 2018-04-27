using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace retake.Models {
 public abstract class BaseEntity {}
	public class User : BaseEntity {

		[Key]
        public int UserId {get; set;}   //these variable names must match the table column names exactly
		public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public List<ActivityModel> activities {get; set;}
        public List<Joiner> joiners {get; set;}
        public User(){
            activities = new List<ActivityModel>();
            joiners = new List<Joiner>();
        }
        }
    }
