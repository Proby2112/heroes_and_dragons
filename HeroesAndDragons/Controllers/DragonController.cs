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
    [Route("api/dragon")]
    public class DragonController : DefaultController<DragonAddApiModel, DragonGetFullApiModel, DragonEntity, string>
    {
        new IDragonService _service;

        public DragonController(IDragonService service) : base(service)
        {
            _service = service;
        }

        /// <summary>
        /// Take all Dragon models
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get_all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] BaseFilterApiModel rangeInfo)
        {
            return await base.GetAll(rangeInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get_alive")]
        public async Task<IActionResult> GetAliveAsync([FromQuery] DragonFilterApiModel filterModel)
        {
            try
            {
                var models = await _service.GetAlive(filterModel);

                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Take model Dragon by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byid")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            return await base.GetById(id);
        }

        /// <summary>
        /// Get collection of DragonEntities for authenticated Hero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("for_current_hero")]
        public async Task<IActionResult> GetForHeroAsync([FromQuery] DragonSortApiModel filterModel)
        {
            try
            {
                var heroId = UserId;
                var model = await _service.GetForCurrentHero(filterModel, heroId);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Update model Dragon
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] DragonAddApiModel model)
        {
            return await base.Put(id, model);
        }

        /// <summary>
        /// Add new model Dragon
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync()
        {
            var model = new DragonAddApiModel
            {
                Hp = 0,
                Id = null,
                Name = null
            };

            return await base.Post(model);
        }

        /// <summary>
        /// Remove model Dragon from id
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
