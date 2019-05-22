using HeroesAndDragons.BL.Managers;
using HeroesAndDragons.BL.Services.Base;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Managers;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.BL.Services
{
    public class DragonService : BaseService<DragonAddApiModel, DragonGetFullApiModel, DragonEntity, string>, IDragonService
    {
        public DragonService(IDragonRepository repository, IDataAdapter dataAdapter) : base(repository, dataAdapter) { }

        public override async Task<DragonGetFullApiModel> AddAsync(DragonAddApiModel model)
        {
            model.Hp = model.Hp.RandInRange(80, 100);
            model.Name = model.Name.CreateName(10);

            return await base.AddAsync(model);
        }
    }

}


