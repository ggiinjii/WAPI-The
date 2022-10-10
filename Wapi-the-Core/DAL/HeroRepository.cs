using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Wapi_the_Infra.Models;
using Wapi_the_Core.DTO;

namespace Wapi_the_Core.DAL
{
    public class HeroRepository : IHeroRepository, IDisposable
    {
        private modelContext context;
        private bool disposed = false;
        private readonly IMapper _mapper;

        public HeroRepository(modelContext context, IMapper mapper)
        {
            this.context = context;

            _mapper = mapper;
        }

        public IEnumerable<HeroDto> GetHeroes()
        {
            return _mapper.Map<List<HeroDto>>(context.Hero.ToList());
        }

        public HeroDto GetHeroByID(int id)
        {
            return _mapper.Map<HeroDto>(context.Hero.Find(id));
        }

        public void InsertHero(HeroDto student)
        {
            context.Hero.Add(_mapper.Map<Hero>(student));
        }

        public void DeleteHero(int studentID)
        {
            HeroDto myhero = GetHeroByID(studentID);
            context.Hero.Remove(_mapper.Map<Hero>(myhero));
        }

        public void UpdateHero(HeroDto student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
