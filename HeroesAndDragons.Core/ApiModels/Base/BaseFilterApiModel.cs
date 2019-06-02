using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static HeroesAndDragons.Core.Enums.RequestEnums;

namespace HeroesAndDragons.Core.ApiModels.Base
{
    public class BaseFilterApiModel
    {
        [JsonProperty("start")]         public int? Start { get; set; }
        [JsonProperty("count")]         public int? Count { get; set; }
        [JsonProperty("option_filter")] public bool OptionFilter { get; set; }
    }
}
