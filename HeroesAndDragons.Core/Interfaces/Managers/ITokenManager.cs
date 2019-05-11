using HeroesAndDragons.Core.Interfaces.DL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.Core.Interfaces.Managers
{
    public interface ITokenManager<TEntity, TKey> 
        where TEntity : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Get the new token
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="remember"></param>
        /// <returns></returns>
        Task<string> GetToken(TEntity entity, bool remember = false);

        /// <summary>
        /// Refresh existing token
        /// </summary>
        /// <returns></returns>
        Task<string> RefreshToken();

    }
}
