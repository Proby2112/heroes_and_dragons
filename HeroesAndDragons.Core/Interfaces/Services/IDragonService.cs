using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Interfaces.Services
{
    public interface IDragonService : IBaseService<DragonAddApiModel, DragonGetFullApiModel, DragonEntity, string>
    {
    }
}
