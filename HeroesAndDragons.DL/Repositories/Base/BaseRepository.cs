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

    static class BaseRepositoryExtension
    {
        public static T Copy<T>(this T fromObj) where T : class, new()
        {
            if (fromObj == null)
            {
                return null;
            }

            var obj = new T();

            var fields1 = obj.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual).ToArray();
            var fields2 = fromObj.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual).ToArray();

            for (int i = 0; i < fields2.Length; i++)
            {
                var value = fields2[i].GetValue(fromObj);

                if (fields2[i].GetMethod.ReturnType.Name.Contains("ICollection"))
                {
                    continue;
                }

                var first = fields1.FirstOrDefault(x => x.Name == fields2[i].Name);
                var setMethod = first.GetSetMethod(false);

                if (setMethod != null)
                {
                    //setMethod.Invoke(obj, new[] { value });
                    first?.SetValue(obj, value);
                }
            }

            return obj;
        }

        public static bool Copy<T>(this T obj, T fromObj)
        {
            if (obj == null || fromObj == null)
            {
                return false;
            }

            bool isChanged = false;

            var fields1 = obj.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual).ToArray();
            var fields2 = fromObj.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual).ToArray();

            for (int i = 0; i < fields2.Length; i++)
            {
                var originValue = fields2[i].GetValue(obj);
                var value = fields2[i].GetValue(fromObj);

                if (fields2[i].GetMethod.ReturnType.Name.Contains("ICollection")
                    || fields2[i].Name == "Created")
                {
                    continue;
                }

                if ((value == null && originValue != null) || (originValue == null && value != null)
                    || (value != null && originValue != null && !value.Equals(originValue)))
                {
                    isChanged = true;
                }

                var first = fields1.FirstOrDefault(x => x.Name == fields2[i].Name);
                var setMethod = first.GetSetMethod(false);

                if (setMethod != null)
                {
                    //setMethod.Invoke(obj, new[] { value });
                    first?.SetValue(obj, value);
                }
            }

            return isChanged;
        }
    }
}
