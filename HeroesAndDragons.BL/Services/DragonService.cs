using HeroesAndDragons.BL.Services.Base;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Helpers;
using HeroesAndDragons.Core.Interfaces.Managers;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.BL.Services
{
    public class DragonService : BaseService<DragonAddApiModel, DragonGetFullApiModel, DragonEntity, string>, IDragonService
    {
        new IDragonRepository _repository;

        public DragonService(IDragonRepository repository, IDataAdapter dataAdapter) : base(repository, dataAdapter)
        {
            _repository = repository;
        }

        public override async Task<DragonGetFullApiModel> AddAsync(DragonAddApiModel model)
        {
            model.Hp = model.Hp.RandInRange(80, 101);
            model.Name = model.Name.CreateName(10);

            return await base.AddAsync(model);
        }

        public async Task<IEnumerable<DragonGetMinApiModel>> GetAlive(DragonFilterApiModel filterModel)
        {
            IEnumerable<DragonEntity> entities;

            if (filterModel?.OptionFilter == false)
            {
                entities = await _repository.GetAliveAsync(filterModel);
            }
            else
            {
                entities = await _repository.GetByFilter(filterModel);
            }

            return _dataAdapter.Parse<DragonEntity, DragonGetMinApiModel>(entities);
        }

        public async Task<IEnumerable<DragonGetMinApiModel>> GetForCurrentHero(DragonSortApiModel filterModel, string heroId)
        {
            var entities = await _repository.GetForCurrentHero(filterModel, heroId);

            return _dataAdapter.Parse<DragonEntity, DragonGetMinApiModel>(entities);
        }
    }

}


