using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace UserProfileApi.Models
{


    public class UsersDetail
    {
        public Int32 id { set; get; }
        public string firstName { set; get; }
        public string middleName { set; get; }
        public string lastName { set; get; }
        public string email { set; get; }
        public string address { set; get; }
        public string phone { set; get; }
    }

    public class User
    {
        [Required]        
        public string username { set; get; }
        [Required]
        public string password { set; get; }
    }

    public class UserResult
    {
        public bool result { set; get; }
        public string token { set; get; }
        public string message { set; get; }
    }
}