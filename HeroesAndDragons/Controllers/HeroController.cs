using HeroesAndDragons.Controllers.Base;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HeroesAndDragons.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/hero")]
    public class HeroController : DefaultController<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string>
    {
        new IHeroService _service;

        public HeroController(IHeroService service) : base(service)
        {
            _service = service;
        }

        /// <summary>
        /// Take all Hero models
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync([FromQuery] HeroFilterApiModel filterModel)
        {
            try
            {
                var models = await _service.GetAllAsync(filterModel);

                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Take model Hero by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byid/{id}")]
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
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] HeroAddApiModel model)
        {
            return await base.Put(id, model);
        }

        /// <summary>
        /// Add new model Hero
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] HeroAddApiModel model)
        {
            return await base.Post(model);
        }

        /// <summary>
        /// Remove model Hero from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return await base.Delete(id);
        }
    }

}
