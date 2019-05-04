using HeroesAndDragons.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Entities
{
    public class HitEntity : BaseEntity<string>
    {
        public int ImpactForce { get; set; }

        public string HeroId { get; set; }
        public virtual HeroEntity Hero { get; set; }

        public string DragonId { get; set; }
        public virtual DragonEntity Dragon { get; set; }
    }
}
