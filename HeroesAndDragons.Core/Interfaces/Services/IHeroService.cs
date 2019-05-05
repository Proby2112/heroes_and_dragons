using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Interfaces.Services
{

    public interface IHeroService : IBaseService<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string>
    {
    }
}


