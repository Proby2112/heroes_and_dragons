using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels.Base
{
    public class RegistrationApiModel
    {
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords doesn`t match")]
        [DataType(DataType.Password)]
        [JsonProperty("confirm_password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [JsonProperty("user")]
        public HeroAddApiModel Hero { get; set; }

        [JsonProperty("remember")]
        public bool Remember { get; set; }
    }
}
