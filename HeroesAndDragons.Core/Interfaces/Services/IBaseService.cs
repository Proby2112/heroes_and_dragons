using HeroesAndDragons.Core.Interfaces.BL;
using HeroesAndDragons.Core.Interfaces.DL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.Core.Interfaces.Services
{
    public interface IBaseService<TModelToAdd, TModel, TEntity, TKey>
        where TModelToAdd : class, IBaseModel<TKey>
        where TModel : class, IBaseModel<TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        Task<List<TModel>> GetAll();

        Task<TModel> Get(TKey id);

        Task<TModel> AddAsync(TModelToAdd model);

        Task<TModel> Update(TKey id, TModelToAdd model);

        Task Remove(TKey id);
    }
}
