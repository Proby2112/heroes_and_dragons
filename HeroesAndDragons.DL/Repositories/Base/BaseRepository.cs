using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Helpers;
using HeroesAndDragons.Core.Interfaces.DL;
using HeroesAndDragons.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.DL.Repositories.Base
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        protected IGenericRepository<TEntity, TKey> _repository;


        public BaseRepository(IGenericRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public virtual Task AddAsync(TEntity item)
        {

            item.SetId();

            _repository.Insert(new List<TEntity>() { item });
            return Task.FromResult("Ok");
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var res = _repository.Table.ToList();
            return Task.FromResult<IEnumerable<TEntity>>(res);
        }

        public Task<IEnumerable<TEntity>> GetRange(RangeInfoApiModel rangeInfo)
        {
            var res = _repository.GetRange(rangeInfo);
            return Task.FromResult<IEnumerable<TEntity>>(res);
        }

        public virtual Task RemoveAsync(TEntity entity)
        {
            _repository.Delete(new List<TEntity>() { entity });
            return Task.FromResult("Ok");
        }

        public virtual Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            _repository.Delete(entities);
            return Task.FromResult("Ok");
        }

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> search)
        {
            var result = _repository.Table.Any(search);
            return Task.FromResult(result);
        }

        public virtual Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> search)
        {
            var result = _repository.Table.Where(search);
            return Task.FromResult(result);
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> search)
        {
            var result = _repository.Table.Where(search).FirstOrDefault();
            return Task.FromResult(result);
        }

        public virtual Task<TEntity> GetAsync(TKey id)
        {
            var res = _repository.Table.FirstOrDefault(x => x.Id.Equals(id));
            if (res == null)
            {
                throw new ArgumentException($"Model id: {id} is not found");
            }

            return Task.FromResult(res);
        }

        public virtual Task RemoveAsync(TKey id)
        {
            var res = _repository.Table.ToList().Find(x => x.Id.Equals(id));
            if (res == null)
            {
                throw new ArgumentException($"Model id: {id} is not found");
            }

            _repository.Delete(new List<TEntity>() { res });
            return Task.FromResult("Ok");
        }

        public virtual Task PutAsync(TKey id, TEntity item)
        {
            var res = _repository.Table.FirstOrDefault(x => x.Id.Equals(id));
            if (res == null)
            {
                throw new ArgumentException($"Model id: {id} is not found");
            }

            if (res != item)
            {
                res.Copy(item);
            }
            res.Updated = DateTime.UtcNow;
            _repository.SaveChanges();

            return Task.FromResult("Ok");
        }
    }
}
