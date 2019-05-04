using HeroesAndDragons.Core.ApiModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels
{

    public abstract class HeroBaseApiModel : BaseModel<string>
    {
        [JsonProperty("name")]      public string UserName { get; set; }
        [JsonProperty("weapon")]    public int Weapon { get; set; }
    }
    public class HeroGetFullApiModel : HeroBaseApiModel
    {
        [JsonProperty("hits")]      public List<HitGetMinApiModel> Hits { get; set; }
    }
    public class HeroGetMinApiModel : HeroBaseApiModel
    {
    }
    public class HeroAddApiModel : HeroBaseApiModel
    {
    }

}
