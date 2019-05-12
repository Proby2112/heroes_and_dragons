using HeroesAndDragons.Core.Interfaces.BL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels.Base
{
    public class AuthApiResult : IResult
    {
        public AuthApiResult()
        {
            Token = null;
            TokenType = "Bearer";
            User = null;
            ResultStatus = ResultStatus.Failed;
        }

        [JsonProperty("token")]             public string Token { get; set; }
        [JsonProperty("token_type")]        public string TokenType { get; set; }
        [JsonProperty("user")]              public HeroGetFullApiModel User { get; set; }
        [JsonProperty("result_status")]     public ResultStatus ResultStatus { get; set; }
    }
}
