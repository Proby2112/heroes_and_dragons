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
    [Authorize]
    [Route("api/dragon")]
    public class DragonController : DefaultController<DragonAddApiModel, DragonGetFullApiModel, DragonEntity, string>
    {
        public DragonController(IDragonService service) : base(service) { }

        /// <summary>
        /// Take all Dragon models
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get_all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return await base.GetAll();
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
