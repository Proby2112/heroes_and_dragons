using HeroesAndDragons.Controllers.Base;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeroesAndDragons.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/hit")]
    public class HitController : DefaultController<HitAddApiModel, HitGetFullApiModel, HitEntity, string>
    {
        public HitController(IHitService service) : base(service) { }

        /// <summary>
        /// Take all Hit models
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllAsync([FromQuery] BaseFilterApiModel rangeInfo)
        {
            return await base.GetAll(rangeInfo);
        }

        /// <summary>
        /// Take model Hit by id
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
        /// Update model Hit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] HitAddApiModel model)
        {
            return await base.Put(id, model);
        }

        /// <summary>
        /// Add new model Hit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync([FromBody] HitAddApiModel model)
        {
            model.HeroId = UserId;

            return await base.Post(model);
        }

        /// <summary>
        /// Remove model Hit from id
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
