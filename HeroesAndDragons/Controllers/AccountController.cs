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
    [Authorize]
    [Route("api/account")]
    public class AccountController : DefaultController<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string>
    {
        readonly ITokenManager<HeroEntity, string> _tokenManager;
        readonly new IHeroService _service;

        public AccountController(IHeroService service, ITokenManager<HeroEntity, string> tokenManager) : base(service)
        {
            _service = service;
            _tokenManager = tokenManager;
        }

        [HttpPost("sing_in")]
        public async Task<IActionResult> SingIn([FromBody] AuthenticationApiModel madel)
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
        [AllowAnonymous]
        public async Task<IActionResult> SingUp([FromBody] RegistrationApiModel model)
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
    }
}