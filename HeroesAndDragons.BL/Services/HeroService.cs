using HeroesAndDragons.BL.Services.Base;
using HeroesAndDragons.Core;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.ApiModels.Base;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Managers;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndDragons.BL.Services
{

    public class HeroService : BaseService<HeroAddApiModel, HeroGetFullApiModel, HeroEntity, string>, IHeroService
    {
        ITokenManager<HeroEntity, string> _tokenManager;
        UserManager<HeroEntity> _userManager;

        public HeroService(IHeroRepository repository, IDataAdapter dataAdapter, ITokenManager<HeroEntity, string> tokenManager, UserManager<HeroEntity> userManager) : base(repository, dataAdapter)
        {
            _tokenManager = tokenManager;
            _userManager = userManager;
        }

        public async Task<HeroGetFullApiModel> AddAsync(RegistrationApiModel model)
        {
            var entity = await Create(model.Hero, model.Password);
            var modelResult = _dataAdapter.Parse<HeroEntity, HeroGetFullApiModel>(entity);

            return modelResult;
        }

        public async Task<HeroEntity> AddForAuthAsync(RegistrationApiModel model)
        {
            var entity = await Create(model.Hero, model.Password);

            return entity;
        }

        private async Task<HeroEntity> Create(HeroAddApiModel model, string password)
        {
            var entity = _dataAdapter.Parse<HeroAddApiModel, HeroEntity>(model);
            await _userManager.CreateAsync(entity, password);

            entity = await _repository.GetAsync(entity.Id);

            return entity;
        }

        public async Task<AuthApiResult> Authenticate(HeroEntity entity, string password)
        {
            string accessToken = null;
            var confirmPassword = _userManager.PasswordHasher.VerifyHashedPassword(entity, entity.PasswordHash, password);
            var modelResult = _dataAdapter.Parse<HeroEntity, HeroGetFullApiModel>(entity);
            var resultStatus = ResultStatus.Failed;

            if (confirmPassword == PasswordVerificationResult.Success)
            {
                accessToken = await _tokenManager.GetToken(entity);
                resultStatus = ResultStatus.Succeeded;
            }

            var authResult = new AuthApiResult
            {
                ResultStatus = resultStatus,
                Token = accessToken,
                User = modelResult
            };

            return authResult;
        }
    }

}
