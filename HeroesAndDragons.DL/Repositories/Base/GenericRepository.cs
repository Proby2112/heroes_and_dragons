using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Interfaces.DL;
using HeroesAndDragons.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static HeroesAndDragons.Core.Enums.RequestEnums;

namespace HeroesAndDragons.DL.Repositories.Base
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
            where TEntity : class, IBaseEntity<TKey>
            where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        AppDbContext _context;
        DbSet<TEntity> _entities;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<TEntity>();
                }
                return _entities;
            }
        }

        public DbSet<TEntity> Table
        {
            get
            {
                return Entities;
            }
        }


        public virtual TEntity GetById(string id)
        {
            return this.Entities.Find(id);
        }

        public virtual IEnumerable<TEntity> GelAll()
        {
            return Entities;
        }

        public virtual bool Insert(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(entity => Entities.Add(entity));
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual bool Insert(TEntity entity)
        {
            return Insert(new List<TEntity>() { entity });
        }

        public virtual bool Update(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(entity =>
            {
                _context.Entry(entity).State = EntityState.Modified;
            });

            _context.SaveChanges();
            return true;
        }

        public virtual bool Update(TEntity entity)
        {
            return Update(new List<TEntity>() { entity });
        }

        public virtual bool Delete(IEnumerable<TEntity> entities)
        {
            try
            {
                entities.ToList().ForEach(entity => Entities.Remove(entity));
                _context.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public virtual bool Delete(TEntity entity)
        {
            return Delete(new List<TEntity>() { entity });
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Entry<T, TK>(T primary, EntityState state)
            where T : class, IBaseEntity<TK>
            where TK : IEquatable<TK>, IComparable<TK>
        {
            _context.Entry(primary).State = state;
        }
    }
}
