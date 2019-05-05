using HeroesAndDragons.Controllers.Base;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesAndDragons.Controllers
{

    [ApiController]
    //[Authorize]
    [Route("api/hero")]
    public class HeroController : DefaultController<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string>
    {
        public HeroController(IHeroService service) : base(service) { }

        /// <summary>
        /// Take all Hero models
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return await base.GetAll();
        }

        /// <summary>
        /// Take model Hero by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byid/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            return await base.GetById(id);
        }

        /// <summary>
        /// Update model Hero
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] HeroAddApiModel model)
        {
            return await base.Put(id, model);
        }

        /// <summary>
        /// Add new model Hero
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync([FromBody] HeroAddApiModel model)
        {
            return await base.Post(model);
        }

        /// <summary>
        /// Remove model Hero from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return await base.Delete(id);
        }
    }

}
