using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Interfaces.DL
{
    public interface IBaseEntity<T> where T : IEquatable<T>, IComparable<T>
    {
        T Id { get; set; }

        DateTime Created { get; set; }
        DateTime Updated { get; set; }

        void SetId();
    }
}
