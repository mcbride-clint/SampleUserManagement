using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleUserManagement.Models
{
    public class User
    {
        [Display(Name = "User ID")]
        public string userId { get; set; }

        [Display(Name = "First Name")]
        [JsonProperty(PropertyName = "first_name")]
        public string firstName { get; set; }


        [Display(Name = "Last Name")]
        [JsonProperty(PropertyName = "last_name")]
        public string lastName { get; set; }


        [Display(Name = "Department")]
        public string department { get; set; }


        [Display(Name = "Phone Number")]
        [JsonProperty(PropertyName = "phone_number")]
        public string phoneNumber { get; set; }
    }
}
