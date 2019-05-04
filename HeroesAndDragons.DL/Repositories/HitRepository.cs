using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.DL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.DL.Repositories
{

    public class HitRepository : BaseRepository<HitEntity, string>, IHitRepository
    {
        public HitRepository(IGenericRepository<HitEntity, string> repository) : base(repository) { }
    }

}
