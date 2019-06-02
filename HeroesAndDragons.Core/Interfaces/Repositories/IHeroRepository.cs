using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.Core.Interfaces.Repositories
{
    public interface IHeroRepository : IBaseRepository<HeroEntity, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IEnumerable<HeroEntity>> GetByFilter(HeroFilterApiModel model);
    }
}
