using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.DL.Repositories.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.DL.Repositories
{

    public class DragonRepository : BaseRepository<DragonEntity, string>, IDragonRepository
    {
        public DragonRepository(IGenericRepository<DragonEntity, string> repository) : base(repository) { }
    }

}
