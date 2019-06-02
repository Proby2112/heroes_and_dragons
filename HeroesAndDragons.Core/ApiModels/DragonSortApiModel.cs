using HeroesAndDragons.Core.ApiModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static HeroesAndDragons.Core.Enums.RequestEnums;

namespace HeroesAndDragons.Core.ApiModels
{
    public class DragonSortApiModel : BaseFilterApiModel
    {
        [JsonProperty("sort_type")] public DragonSortEnum SortType { get; set; }
    }
}
