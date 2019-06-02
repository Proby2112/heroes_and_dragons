using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels
{

    public abstract class DragonBaseApiModel : BaseModel<string>
    {
        [JsonProperty("name")]          public string Name { get; set; }
        [JsonProperty("hp")]            public int Hp { get; set; }
        [JsonProperty("current_hp")]    public int? CurrentHp { get; set; }
        [JsonProperty("damage")]        public int? Damage { get; set; }
        [JsonProperty("dragon_state")]  public DragonStateEnum DragonState { get; set; }
    }
    public class DragonGetFullApiModel : DragonBaseApiModel
    {
        [JsonProperty("hits")]          public List<HitGetMinApiModel> Hits { get; set; }
    }
    public class DragonGetMinApiModel : DragonBaseApiModel
    {
    }
    public class DragonAddApiModel : DragonBaseApiModel
    {
    }

}
