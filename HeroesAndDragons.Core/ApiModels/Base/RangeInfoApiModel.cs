using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static HeroesAndDragons.Core.Enums.RequestEnums;

namespace HeroesAndDragons.Core.ApiModels.Base
{
    public class RangeInfoApiModel
    {
        [JsonProperty("start")]     public int? Start { get; set; }
        [JsonProperty("count")]     public int? Count { get; set; }
        [JsonProperty("sort")]      public SortEnum Sort { get; set; }
    }
}
