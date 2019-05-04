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
            //todo change time
            //item.ChangeTimeToUtc();

            item.SetId();

            _repository.Insert(new List<TEntity>() { item });
            return Task.FromResult("Ok");
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var res = _repository.Table.ToList();
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

        public virtual Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> search)
        {
            var result = _repository.Table.Where(search).ToList();
            return Task.FromResult<IEnumerable<TEntity>>(result);
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> search)
        {
            var result = _repository.Table.Where(search).FirstOrDefault();
            return Task.FromResult<TEntity>(result);
        }

        //public virtual Task AddOrUpdateAsync(TEntity entity)
        //{
        //    var first = _repository.Table.Where(x => x.Id.Equals(entity.Id)).FirstOrDefault();

        //    //todo change time
        //    //entity.ChangeTimeToUtc();

        //    if (first == null)
        //    {
        //        entity.SetId();
        //        _repository.Insert(entity);
        //    }
        //    else
        //    {
        //        var uptime = first.Created;
        //        if (first != entity)
        //        {
        //            first.Copy(entity);
        //        }
        //        first.Created = uptime;
        //        first.Updated = DateTime.UtcNow;

        //        _repository.SaveChanges();
        //    }

        //    return Task.FromResult("Ok");
        //}

        public virtual Task<TEntity> GetAsync(TKey id)
        {
            var res = _repository.Table.FirstOrDefault(x => x.Id.Equals(id));
            if (res == null)
            {
                throw new ArgumentException($"Model id: {id} is not found");
            }

            return Task.FromResult<TEntity>(res);
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

        //public virtual Task PutAsync(TKey id, TEntity item)
        //{
        //    var res = _repository.Table.FirstOrDefault(x => x.Id.Equals(id));
        //    if (res == null)
        //    {
        //        throw new ArgumentException($"Model id: {id} is not found");
        //    }

        //    //todo change time
        //    //item.ChangeTimeToUtc();

        //    if (res != item)
        //    {
        //        res.Copy(item);
        //    }
        //    res.Updated = DateTime.UtcNow;
        //    _repository.SaveChanges();

        //    return Task.FromResult("Ok");
        //}

        public Task<int> SqlQuery(string sql)
        {
            var result = _repository.SqlQuery(sql);
            return Task.FromResult(result);

        }
    }
}
