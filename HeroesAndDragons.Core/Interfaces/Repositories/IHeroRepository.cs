using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Interfaces.Repositories
{
    public interface IHeroRepository : IBaseRepository<HeroEntity, string> { }
}
