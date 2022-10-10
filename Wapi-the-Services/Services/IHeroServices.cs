using System;
using System.Collections.Generic;
using System.Text;
using Wapi_the_Core.DTO;

namespace Wapi_the_Services.Services
{
    internal interface IHeroServices
    {
        public bool HeroExists(int id);
        public bool Delete(int id);
        public HeroDto Edit(int id, HeroDto hero);
        public List<HeroDto> getHeroes();
        public HeroDto getHeroId(int id);
        public HeroDto Create(HeroDto hero);
    }
}
