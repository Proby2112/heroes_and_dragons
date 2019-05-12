using HeroesAndDragons.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Entities
{
    public class DragonEntity : BaseEntity<string>
    {
        public string Name { get; set; }
        public int? Hp { get; set; }

        public virtual ICollection<HitEntity> Hits { get; set; }
    }
}
