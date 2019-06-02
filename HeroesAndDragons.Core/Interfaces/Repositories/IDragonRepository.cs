using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.Core.Interfaces.Repositories
{
    public interface IDragonRepository : IBaseRepository<DragonEntity, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterModel"></param>
        /// <returns></returns>
        Task<IEnumerable<DragonEntity>> GetAliveAsync(BaseFilterApiModel filterModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IEnumerable<DragonEntity>> GetByFilter(DragonFilterApiModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterModel"></param>
        /// <param name="heroId"></param>
        /// <returns></returns>
        Task<IEnumerable<DragonEntity>> GetForCurrentHero(DragonSortApiModel filterModel, string heroId);
    }
}
