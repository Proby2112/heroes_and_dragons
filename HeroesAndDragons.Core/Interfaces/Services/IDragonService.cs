using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.Core.Interfaces.Services
{
    public interface IDragonService : IBaseService<DragonAddApiModel, DragonGetFullApiModel, DragonEntity, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IEnumerable<DragonGetMinApiModel>> GetAliveAsync(DragonFilterApiModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        Task<IEnumerable<DragonGetMinApiModel>> GetForCurrentHeroAsync(DragonSortApiModel filterModel, string heroId);
    }
}
