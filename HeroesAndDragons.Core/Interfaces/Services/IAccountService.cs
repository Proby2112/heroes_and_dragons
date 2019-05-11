using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Interfaces.BL;
using HeroesAndDragons.Core.Interfaces.DL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.Core.Interfaces.Services
{
    public interface IAccountService<TModelToAdd, TModel, TEntity, TKey, TResult> : IBaseService<TModelToAdd, TModel, TEntity, TKey>
        where TModelToAdd : class, IBaseModel<TKey>
        where TModel : class, IBaseModel<TKey>
        where TEntity : IdentityUser, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
        where TResult : IResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<TResult> Authenticate(TEntity entity, string password);
    }
}
