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

    public class HitService : BaseService<HitAddApiModel, HitGetFullApiModel, HitEntity, string>, IHitService
    {
        public HitService(IHitRepository repository, IDataAdapter dataAdapter) : base(repository, dataAdapter) { }
    }

}
