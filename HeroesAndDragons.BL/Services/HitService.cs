using HeroesAndDragons.BL.Services.Base;
using HeroesAndDragons.Core.ApiModels;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Helpers;
using HeroesAndDragons.Core.Interfaces.Managers;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace HeroesAndDragons.BL.Services
{

    public class HitService : BaseService<HitAddApiModel, HitGetFullApiModel, HitEntity, string>, IHitService
    {
        IDragonRepository _dragonRepository;
        IHeroRepository _heroRepository;

        public HitService(IHitRepository repository, IDragonRepository dragonRepository, IHeroRepository heroRepository, IDataAdapter dataAdapter) : base(repository, dataAdapter)
        {
            _dragonRepository = dragonRepository;
            _heroRepository = heroRepository;
        }

        public override async Task<HitGetFullApiModel> AddAsync(HitAddApiModel model)
        {
            // Check dragon entity. If it doesn`t, then throw an exception
            var dragon = await _dragonRepository.GetAsync(model.DragonId);
            var hero = await _heroRepository.GetAsync(model.HeroId);

            dragon.Hp -= model.ImpactForce = hero.Weapon.ImpactForce();

            await _dragonRepository.PutAsync(dragon.Id, dragon);

            return await base.AddAsync(model);
        }
    }

}
