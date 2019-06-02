using HeroesAndDragons.Core.ApiModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels
{
    public class HeroFilterApiModel : BaseFilterApiModel
    {
        [JsonProperty("name")]                  public string Name { get; set; }
        [JsonProperty("greater_creation_time")] public DateTime? MinCreationTime { get; set; }
        [JsonProperty("Lesser_creation_time")]  public DateTime? MaxCreationTime { get; set; }
    }
}
