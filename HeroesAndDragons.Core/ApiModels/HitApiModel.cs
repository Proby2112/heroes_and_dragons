﻿using HeroesAndDragons.Core.ApiModels.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels
{
    public abstract class HitBaseApiModel : BaseModel<string>
    {
        [JsonProperty("impact_force")]  public int ImpactForce { get; set; }

    }
    public class HitGetFullApiModel : HitBaseApiModel
    {
        [JsonProperty("hero")]          public HeroGetMinApiModel Hero { get; set; }
        [JsonProperty("dragon")]        public DragonGetMinApiModel Dragon { get; set; }
    }
    public class HitGetMinApiModel : HitBaseApiModel
    {
        [JsonProperty("hero_id")]       public string HeroId { get; set; }
        [JsonProperty("dragon_id")]     public string DragonId { get; set; }
    }
    public class HitAddApiModel : HitBaseApiModel
    {
    }

}
