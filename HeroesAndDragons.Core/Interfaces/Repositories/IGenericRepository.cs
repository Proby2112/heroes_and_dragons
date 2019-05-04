using HeroesAndDragons.Core.Interfaces.DL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity, TKey>
            where TEntity : class, IBaseEntity<TKey>
            where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        DbSet<TEntity> Table { get; }

        TEntity GetById(string id);
        IEnumerable<TEntity> GelAll();

        bool Insert(IEnumerable<TEntity> entities);
        bool Insert(TEntity entity);

        bool Update(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);

        bool Delete(IEnumerable<TEntity> entities);
        bool Delete(TEntity entity);

        TEntity GetSingle();

        void Entry<T, TK>(T primary, EntityState state)
            where T : class, IBaseEntity<TK>
            where TK : IEquatable<TK>, IComparable<TK>;

        bool SaveChanges();
        int SqlQuery(string sql);
    }
}
