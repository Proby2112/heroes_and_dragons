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
        Task<TEntity> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync(BaseFilterApiModel filterModel);

        Task AddAsync(TEntity item);

        Task RemoveAsync(TKey id);
        Task RemoveAsync(TEntity entity);

        Task PutAsync(TKey id, TEntity item);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> search);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> search);
        Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> search);
    }
}
