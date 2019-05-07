using HeroesAndDragons.BL.Services.Base;
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
        UserManager<HeroEntity> _userManager;

        public HeroService(IHeroRepository repository, IDataAdapter dataAdapter, UserManager<HeroEntity> userManager) : base(repository, dataAdapter)
        {
            _userManager = userManager;
        }

        public async Task<HeroGetFullApiModel> AddAsync(RegistrationApiModel model)
        {
            HeroAddApiModel hero = model.Hero; 

            var entity = _dataAdapter.Parse<HeroAddApiModel, HeroEntity>(hero);
            var result = await _userManager.CreateAsync(entity, model.Password);

            entity = await _repository.GetAsync(entity.Id);
            var modelResult = _dataAdapter.Parse<HeroEntity, HeroGetFullApiModel>(entity);

            return modelResult;
        }
    }

}
