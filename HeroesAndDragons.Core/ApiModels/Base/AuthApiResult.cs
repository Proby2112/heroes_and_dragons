using HeroesAndDragons.Core.Interfaces.BL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels.Base
{
    public class AuthApiResult : IResult
    {
        [JsonProperty("token")]         public string Token { get; set; }
        [JsonProperty("token_type")]    public string TokenType { get; set; }
        [JsonProperty("user")]          public HeroGetFullApiModel User { get; set; }
        [JsonProperty("result")]        public ResultStatus ResultStatus { get; set; }

        public static AuthApiResult CreateAuthModel(HeroGetFullApiModel user, string token, string tokenType = "Bearer", ResultStatus resultStatus = ResultStatus.Succeeded)
        {
            return new AuthApiResult
            {
                ResultStatus = resultStatus,
                Token = token,
                TokenType = tokenType,
                User = user
            };
        }
    }
}
