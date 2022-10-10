using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Wapi_the_Core.DAL;
using Wapi_the_Core.DTO;
using Wapi_the_Core.Unit_Of_Work;

namespace Wapi_the_Services.Services
{
    public class HeroService: IHeroServices
    {
        private UnitOfWork _unit_Of_Work;
        private readonly IMapper _mapper;

        public HeroService( IMapper mapper)
        {
            _unit_Of_Work = new UnitOfWork(_mapper);
            _mapper = mapper;
        }

        public HeroService(IMapper mapper, IHeroRepository test)
        {
            _unit_Of_Work = new UnitOfWork(_mapper,test);
            _mapper = mapper;
        }


        public bool HeroExists(int id)
        {
            return _unit_Of_Work.HeroRepository.GetHeroes().Any(e => e.Id == id);
        }

        private bool IsHeroDtoValid(HeroDto hero)
        {
            if (hero == null)
                return false;

            if (string.IsNullOrEmpty(hero.Alter))
                return false;

            if (string.IsNullOrEmpty(hero.Name))
                return false;

            return true;
        }

        public bool Delete(int id)
        {
            _unit_Of_Work.HeroRepository.DeleteHero(id);
            return true;
        }

        public HeroDto Edit(int id, HeroDto hero)
        {
            if (id != hero.Id)
            {
                return null;
            }

            try
            {
                _unit_Of_Work.HeroRepository.UpdateHero(hero);
            }
            catch (Exception e)
            {

                throw e;
            }
            return hero;

        }

        public List<HeroDto> getHeroes()
        {
            return _unit_Of_Work.HeroRepository.GetHeroes().ToList();
        }

        public HeroDto getHeroId(int id)
        {
            HeroDto hero = _unit_Of_Work.HeroRepository.GetHeroByID(id);

            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public HeroDto Create(HeroDto hero)
        {
            if (!IsHeroDtoValid(hero))
                return null;

                hero.Id = _unit_Of_Work.HeroRepository.GetHeroes().Count() + 1;


            _unit_Of_Work.HeroRepository.InsertHero(hero);

            return hero;

        }


    }
}
