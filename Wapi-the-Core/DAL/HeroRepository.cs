using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Wapi_the_Core.DTO;
using Wapi_the_Infra.Models;

namespace Wapi_the_Core.DAL
{
    public class HeroRepository : IHeroRepository, IDisposable
    {
        private modelContext _context;
        private bool _disposed = false;
        private readonly IMapper _mapper;

        public HeroRepository(modelContext context, IMapper mapper)
        {
            this._context = context;

            _mapper = mapper;
        }

        public IEnumerable<HeroDto> GetHeroes()
        {
            return _mapper.Map<List<HeroDto>>(_context.Hero.ToList());
        }

        public HeroDto GetHeroByID(int id)
        {
            return _mapper.Map<HeroDto>(_context.Hero.Find(id));
        }

        public void InsertHero(HeroDto student)
        {
            _context.Hero.Add(_mapper.Map<Hero>(student));
        }

        public void DeleteHero(int studentID)
        {
            HeroDto myhero = GetHeroByID(studentID);
            _context.Hero.Remove(_mapper.Map<Hero>(myhero));
        }

        public void UpdateHero(HeroDto student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
