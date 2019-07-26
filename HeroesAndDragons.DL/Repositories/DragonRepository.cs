using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Enums;
using HeroesAndDragons.Core.Helpers;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.DL.Repositories.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static HeroesAndDragons.Core.Enums.RequestEnums;

namespace HeroesAndDragons.DL.Repositories
{

    public class DragonRepository : BaseRepository<DragonEntity, string>, IDragonRepository
    {
        public DragonRepository(IGenericRepository<DragonEntity, string> repository) : base(repository) { }

        public Task<IEnumerable<DragonEntity>> GetAlive(BaseFilterApiModel filterModel)
        {
            var res = _repository.Table
                .Where(e => e.DragonState == DragonStateEnum.IsAlive)
                .OrderBy(e => e.Name)
                .GetRange(filterModel);

            return Task.FromResult<IEnumerable<DragonEntity>>(res);
        }

        public override Task<IEnumerable<DragonEntity>> GetAll(BaseFilterApiModel filterModel)
        {
            var res = _repository.Table
                .OrderBy(e => e.Name)
                .GetRange(filterModel);

            return Task.FromResult<IEnumerable<DragonEntity>>(res);
        }

        public Task<IEnumerable<DragonEntity>> GetByFilter(DragonFilterApiModel model)
        {
            IQueryable<DragonEntity> entities = _repository.Table
                .Where(e => String.IsNullOrEmpty(model.Name) || e.Name.StartsWith(model.Name))
                .Where(e => !model.MinHp.HasValue || e.Hp > model.MinHp.Value)
                .Where(e => !model.MaxHp.HasValue || e.Hp < model.MaxHp.Value)
                .Where(e => !model.MinCurrentHp.HasValue || e.CurrentHp > model.MinCurrentHp.Value)
                .Where(e => !model.MaxCurrentHp.HasValue || e.CurrentHp < model.MaxCurrentHp.Value)
                .Where(e => e.DragonState == DragonStateEnum.IsAlive)
                .OrderBy(e => e.Name)
                .GetRange(model);

            return Task.FromResult<IEnumerable<DragonEntity>>(entities);
        }

        public Task<IEnumerable<DragonEntity>> GetForCurrentHero(DragonSortApiModel filterModel, string heroId)
        {
            var entities = _repository.Table
                .Where(e => e.Hits.Any(h => h.HeroId.Equals(heroId)))
                .GetRange(filterModel)
                .Sort(filterModel.SortType);

            return Task.FromResult(entities);
        }

        public override Task Put(string id, DragonEntity item)
        {
            item.Damage = item.Hp - item.CurrentHp;

            return base.Put(id, item);
        }
    }

}
