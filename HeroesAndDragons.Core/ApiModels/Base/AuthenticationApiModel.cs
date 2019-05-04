using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels.Base
{
    public class AuthenticationApiModel
    {
        [Required]
        [JsonProperty("login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
