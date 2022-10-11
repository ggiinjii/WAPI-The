using AutoMapper;
using System;
using Wapi_the_Core.DAL;
using Wapi_the_Infra.Models;

namespace Wapi_the_Core.Unit_Of_Work
{
    public class UnitOfWork : IDisposable
    {
        private modelContext _context = new modelContext();
        private GenericRepository<Hero> _genericRepository;
        private IHeroRepository _heroRepository;
        private bool _disposed = false;
        private readonly IMapper _mapper;

        public UnitOfWork(IMapper mapper)
        {
            _mapper = mapper;
        }
        public UnitOfWork(IMapper mapper, IHeroRepository test)
        {
            _mapper = mapper;
            if (this._heroRepository == null)
            {
                this._heroRepository = test;
            }
        }
        public GenericRepository<Hero> GenericRepository
        {
            get
            {
                if (this._genericRepository == null)
                {
                    this._genericRepository = new GenericRepository<Hero>(_context);
                }
                return _genericRepository;
            }
        }

        public IHeroRepository HeroRepository
        {
            get
            {
                if (this._heroRepository == null)
                {
                    this._heroRepository = new HeroRepository(_context, _mapper);
                }
                return _heroRepository;
            }
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

