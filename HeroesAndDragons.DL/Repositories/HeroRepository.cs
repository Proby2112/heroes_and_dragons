using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Helpers;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.DL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.DL.Repositories
{

    public class HeroRepository : BaseRepository<HeroEntity, string>, IHeroRepository
    {
        public HeroRepository(IGenericRepository<HeroEntity, string> repository) : base(repository) { }

        public override Task<IEnumerable<HeroEntity>> GetAll(BaseFilterApiModel filterModel)
        {
            var res = _repository.Table.OrderBy(e => e.UserName).GetRange(filterModel);
            return Task.FromResult<IEnumerable<HeroEntity>>(res);
        }

        public Task<IEnumerable<HeroEntity>> GetByFilter(HeroFilterApiModel model)
        {
            IQueryable<HeroEntity> entities = _repository.Table
                .Where(e => String.IsNullOrEmpty(model.Name) || e.UserName.StartsWith(model.Name))
                .Where(e => !model.MinCreationTime.HasValue || e.Created > model.MinCreationTime.Value)
                .Where(e => !model.MaxCreationTime.HasValue || e.Created < model.MaxCreationTime.Value)
                .OrderBy(e => e.UserName)
                .GetRange(model);

            return Task.FromResult<IEnumerable<HeroEntity>>(entities);
        }
    }

}
