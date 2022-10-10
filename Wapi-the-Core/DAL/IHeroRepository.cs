using System;
using System.Collections.Generic;
using Wapi_the_Infra.Models;
using Wapi_the_Core.DTO;

namespace Wapi_the_Core.DAL
{

    public interface IHeroRepository : IDisposable
    {
        IEnumerable<HeroDto> GetHeroes();
        HeroDto GetHeroByID(int studentId);
        void InsertHero(HeroDto student);
        void DeleteHero(int studentID);
        void UpdateHero(HeroDto student);
        void Save();
    }
}

