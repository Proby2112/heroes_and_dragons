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
        Task<IEnumerable<DragonGetMinApiModel>> GetAlive(DragonFilterApiModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        Task<IEnumerable<DragonGetMinApiModel>> GetForCurrentHero(DragonSortApiModel filterModel, string heroId);
    }
}
