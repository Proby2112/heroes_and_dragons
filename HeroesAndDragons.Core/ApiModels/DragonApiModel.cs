using HeroesAndDragons.Core.ApiModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels
{

    public abstract class DragonBaseApiModel : BaseModel<string>
    {
        [JsonProperty("name")]      public string Name { get; set; }
        [JsonProperty("hp")]        public int Hp { get; set; }
    }
    public class DragonGetFullApiModel : DragonBaseApiModel
    {
        [JsonProperty("hits")]      public List<HitGetMinApiModel> Hits { get; set; }
    }
    public class DragonGetMinApiModel : DragonBaseApiModel
    {
    }
    public class DragonAddApiModel : DragonBaseApiModel
    {
    }

}
