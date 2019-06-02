using HeroesAndDragons.BL.Services.Base;
using HeroesAndDragons.Core;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Helpers;
using HeroesAndDragons.Core.Interfaces.Managers;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeroesAndDragons.BL.Services
{

    public class HeroService : BaseService<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string>, IHeroService
    {
        new IHeroRepository _repository;
        ITokenManager<HeroEntity, string> _tokenManager;
        UserManager<HeroEntity> _userManager;

        public HeroService(IHeroRepository repository, IDataAdapter dataAdapter, ITokenManager<HeroEntity, string> tokenManager, UserManager<HeroEntity> userManager) : base(repository, dataAdapter)
        {
            _repository = repository;
            _tokenManager = tokenManager;
            _userManager = userManager;
        }

        public async Task<HeroGetFullApiModel> AddAsync(RegistrationApiModel model)
        {
            var entity = await CreateEntity(model.Hero, model.Password);
            var modelResult = _dataAdapter.Parse<HeroEntity, HeroGetFullApiModel>(entity);

            return modelResult;
        }

        public async Task<HeroEntity> AddForAuthAsync(RegistrationApiModel model)
        {
            var entity = await CreateEntity(model.Hero, model.Password);

            return entity;
        }

        public async Task<AuthApiResult> Authenticate(HeroEntity entity, string password, bool remember)
        {
            var authResult = new AuthApiResult();
            var confirmPassword = _userManager.PasswordHasher.VerifyHashedPassword(entity, entity.PasswordHash, password);

            authResult.User = _dataAdapter.Parse<HeroEntity, HeroGetMinApiModel>(entity);

            if (confirmPassword == PasswordVerificationResult.Success)
            {
                authResult.Token = await _tokenManager.GetToken(entity, remember);
                authResult.ResultStatus = ResultStatusEnum.Succeeded;
            }

            return authResult;
        }

        public async Task<IEnumerable<HeroGetMinApiModel>> GetAll(HeroFilterApiModel filterModel)
        {
            IEnumerable<HeroEntity> entities;

            if (filterModel?.OptionFilter == false)
            {
                entities = await _repository.GetAllAsync(filterModel); 
            }
            else
            {
                entities = await _repository.GetByFilter(filterModel);
            }

            return _dataAdapter.Parse<HeroEntity, HeroGetMinApiModel>(entities);
        }

        public async Task<HeroEntity> GetByUserName(AuthenticationApiModel model)
        {
            var entity = await _userManager.FindByNameAsync(model.Login);

            return entity;
        }

        private async Task<HeroEntity> CreateEntity(HeroAddApiModel model, string password)
        {
            // Set random weapon.
            model.Weapon = model.Weapon.RandInRange(1, 6);
            // Trim whitespase.
            model.UserName = model.UserName.Trim();

            var entity = _dataAdapter.Parse<HeroAddApiModel, HeroEntity>(model);
            var result = await _userManager.CreateAsync(entity, password);

            if (result.Errors.Select(e => e.Code).Contains("DuplicateUserName"))
            {
                throw new System.Data.DuplicateNameException($"Hero {model.UserName} already exist");
            }

            entity = await _repository.GetAsync(entity.Id);

            // Add claims to entity
            IEnumerable<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, entity.UserName),
                new Claim(ClaimTypes.NameIdentifier, entity.Id)
            };
            await _userManager.AddClaimsAsync(entity, claims);

            return entity;
        }
    }

}
