using HeroesAndDragons.Core.Interfaces.BL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroesAndDragons.Core.ApiModels.Base
{
    public class BaseModel<TKey> : IBaseModel<TKey> where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        [JsonProperty("id")]            public TKey Id { get; set; }
        [JsonProperty("cteated_time")]  public DateTime? Created { get; set; }
    }
}
