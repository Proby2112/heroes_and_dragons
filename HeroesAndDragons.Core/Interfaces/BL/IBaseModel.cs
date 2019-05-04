using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Interfaces.BL
{
    public interface IBaseModel<T> where T : IEquatable<T>, IComparable<T>
    {
        T Id { get; set; }
    }
}
