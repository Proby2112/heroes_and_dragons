using HeroesAndDragons.Core.Entities.Base;
using HeroesAndDragons.Core.Interfaces.DL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Entities
{
    public class HeroEntity : IdentityUser, IBaseEntity<string>
    {

        public HeroEntity()
        {
            Created = DateTime.UtcNow;
            Updated = Created;
        }

        public int Weapon { get; set; }

        public virtual ICollection<HitEntity> Hits { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public void SetId()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
