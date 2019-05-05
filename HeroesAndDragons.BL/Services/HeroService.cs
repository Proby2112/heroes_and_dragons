using HeroesAndDragons.BL.Services.Base;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.BL.Services
{

    public class HeroService : BaseService<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string>, IHeroService
    {
        public HeroService(IHeroRepository repository, IDataAdapter dataAdapter) : base(repository, dataAdapter) { }
    }

}
