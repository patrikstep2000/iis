using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iis_web.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter username.")]
        [JsonProperty("username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Please enter password.")]
        [JsonProperty("password")]
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}