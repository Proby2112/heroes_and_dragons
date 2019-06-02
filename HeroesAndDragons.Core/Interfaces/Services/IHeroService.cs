using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.Core.Interfaces.Services
{

    public interface IHeroService : IAccountService<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string, AuthApiResult>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HeroEntity> AddForAuthAsync(RegistrationApiModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<HeroEntity> GetByUserName(AuthenticationApiModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterModel"></param>
        /// <returns></returns>
        Task<IEnumerable<HeroGetMinApiModel>> GetAll(HeroFilterApiModel filterModel);
    }
}


