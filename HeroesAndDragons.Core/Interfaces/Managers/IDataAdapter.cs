using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.Core.Interfaces.Managers
{
    public interface IDataAdapter
    {
        /// <summary>
        /// Map a single model
        /// </summary>
        /// <typeparam name="From">Type of the model to mapping from</typeparam>
        /// <typeparam name="To">Type of the model to mapping to</typeparam>
        /// <param name="model">Model to mapping</param>
        /// <returns>Mapped model</returns>
        To Parse<From, To>(From model);

        /// <summary>
        /// Map a collection of models
        /// </summary>
        /// <typeparam name="From">Type of the model to mapping from</typeparam>
        /// <typeparam name="To">Type of the model to mapping to</typeparam>
        /// <param name="models">Collection of models</param>
        /// <returns>Collection of mapped models</returns>
        IEnumerable<To> Parse<From, To>(IEnumerable<From> models);
    }
}
