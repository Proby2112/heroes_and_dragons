using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Interfaces.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.Core.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        Task<TEntity> Get(TKey id);
        Task<IEnumerable<TEntity>> GetAll(BaseFilterApiModel filterModel);

        Task Add(TEntity item);

        Task Remove(TKey id);
        Task Remove(TEntity entity);

        Task Put(TKey id, TEntity item);

        Task<bool> Any(Expression<Func<TEntity, bool>> search);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> search);
        Task<IQueryable<TEntity>> Where(Expression<Func<TEntity, bool>> search);
    }
}
