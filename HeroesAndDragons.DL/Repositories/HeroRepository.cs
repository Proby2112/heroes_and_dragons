using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.DL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.DL.Repositories
{

    public class HeroRepository : BaseRepository<HeroEntity, string>, IHeroRepository
    {
        public HeroRepository(IGenericRepository<HeroEntity, string> repository) : base(repository) { }
    }

}
