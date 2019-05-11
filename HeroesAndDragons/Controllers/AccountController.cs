using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesAndDragons.Controllers.Base;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Managers;
using HeroesAndDragons.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAndDragons.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : DefaultController<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string>
    {
        readonly new IHeroService _service;

        public AccountController(IHeroService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("sing_in")]
        public async Task<IActionResult> SingIn([FromBody] AuthenticationApiModel model)
        {
            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("sing_up")]
        public async Task<IActionResult> SingUp([FromBody] RegistrationApiModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var entity = await _service.AddForAuthAsync(model);
                var resultModel = await _service.Authenticate(entity, model.Password);

                return Ok(resultModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}