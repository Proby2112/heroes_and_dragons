using HeroesAndDragons.Core.Entities.Base;
using HeroesAndDragons.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Entities
{
    public class DragonEntity : BaseEntity<string>
    {

        public string Name { get; set; }
        public int? Hp { get; set; }
        public int? CurrentHp { get; set; }
        public int? Damage { get; set; }
        public DragonStateEnum DragonState { get; set; }

        public virtual ICollection<HitEntity> Hits { get; set; }
    }
}
