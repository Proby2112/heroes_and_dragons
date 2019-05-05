using HeroesAndDragons.Core.Interfaces.BL;
using HeroesAndDragons.Core.Interfaces.DL;
using HeroesAndDragons.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Controllers.Base
{
    public abstract class DefaultController<TModelToAdd, TModel, TEntity, TKey> : Controller
        where TModelToAdd : class, IBaseModel<TKey>
        where TModel : class, IBaseModel<TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        protected IBaseService<TModelToAdd, TModel, TEntity, TKey> _service;

        public DefaultController(IBaseService<TModelToAdd, TModel, TEntity, TKey> service)
        {
            _service = service;
        }

        protected virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _service.GetAll();

                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        protected virtual async Task<IActionResult> GetById(TKey id)
        {
            try
            {
                var model = await _service.Get(id);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        protected virtual async Task<IActionResult> Post([FromBody]TModelToAdd model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var modelResult = await _service.AddAsync(model);

                return Ok(modelResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        protected virtual async Task<IActionResult> Put(TKey id, [FromBody]TModelToAdd value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var modelResult = await _service.Update(id, value);

                return Ok(modelResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        protected virtual async Task<IActionResult> Delete(TKey id)
        {
            try
            {
                await _service.Remove(id);

                return Ok("Model deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
