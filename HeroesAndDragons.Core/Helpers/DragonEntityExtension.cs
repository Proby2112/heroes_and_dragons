using HeroesAndDragons.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static HeroesAndDragons.Core.Enums.RequestEnums;

namespace HeroesAndDragons.Core.Helpers
{
    public static class DragonEntityExtension
    {
        public static IEnumerable<DragonEntity> Sort(this IEnumerable<DragonEntity> entities, DragonSortEnum sortType)
        {
            switch (sortType)
            {
                case DragonSortEnum.Name:
                    entities = entities.OrderBy(e => e.Name);
                    break;
                case DragonSortEnum.Damage:
                    entities = entities.OrderBy(e => e.Damage);
                    break;
                case DragonSortEnum.DescendingName:
                    entities = entities.OrderByDescending(e => e.Name);
                    break;
                case DragonSortEnum.DescendingDamage:
                    entities = entities.OrderByDescending(e => e.Damage);
                    break;
                default:
                    entities = entities.OrderBy(e => e.Id);
                    break;
            }

            return entities;
        }
    }
}
