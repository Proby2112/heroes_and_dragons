using System;
using System.Data;
using System.Threading.Tasks;
using HeroesAndDragons.Controllers.Base;
using HeroesAndDragons.Core;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAndDragons.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/account")]
    public class AccountController : DefaultController<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string>
    {
        readonly new IHeroService _service;

        public AccountController(IHeroService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] AuthenticationApiModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var entity = await _service.GetByUserNameAsync(model);
                var resultModel = await _service.AuthenticateAsync(entity, model.Password, model.Remember);

                if (resultModel.ResultStatus == ResultStatusEnum.Failed)
                {
                    return Unauthorized();
                }

                return Ok(resultModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] RegistrationApiModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var entity = await _service.AddForAuthAsync(model);
                var resultModel = await _service.AuthenticateAsync(entity, model.Password, model.Remember);

                if (resultModel.ResultStatus == ResultStatusEnum.Failed)
                {
                    return Unauthorized();
                }

                return Ok(resultModel);
            }
            catch (DuplicateNameException ex)
            {
                return StatusCode(405, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}