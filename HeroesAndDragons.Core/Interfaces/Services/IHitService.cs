using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Interfaces.Services
{

    public interface IHitService : IBaseService<HitAddApiModel, HitGetFullApiModel, HitEntity, string>
    {
    }

}
