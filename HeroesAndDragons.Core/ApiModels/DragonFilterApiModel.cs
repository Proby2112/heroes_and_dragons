using HeroesAndDragons.Core.ApiModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static HeroesAndDragons.Core.Enums.RequestEnums;

namespace HeroesAndDragons.Core.ApiModels
{
    public class DragonFilterApiModel : BaseFilterApiModel
    {
        [JsonProperty("name")]               public string Name { get; set; }
        [JsonProperty("greater_hp")]         public int? MinHp { get; set; }      
        [JsonProperty("lesser_hp")]          public int? MaxHp { get; set; }      
        [JsonProperty("greater_current_hp")] public int? MinCurrentHp { get; set; }        
        [JsonProperty("lesser_current_hp")]  public int? MaxCurrentHp { get; set; }        

    }
}
