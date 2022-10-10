using AutoMapper;
using System;
using Wapi_the_Core.DAL;
using Wapi_the_Infra.Models;

namespace Wapi_the_Core.Unit_Of_Work
{
    public class UnitOfWork : IDisposable
    {
        private modelContext context = new modelContext();
        private GenericRepository<Hero> _genericRepository;
        private IHeroRepository heroRepository;
        private bool disposed = false;
        private readonly IMapper _mapper;

        public UnitOfWork(IMapper mapper)
        {
            _mapper = mapper;   
        }
        public UnitOfWork(IMapper mapper, IHeroRepository test)
        {
            _mapper = mapper;
            if (this.heroRepository == null)
            {
                this.heroRepository = test;
            }
        }
        public GenericRepository<Hero> GenericRepository
        {
            get
            {
                if (this._genericRepository == null)
                {
                    this._genericRepository = new GenericRepository<Hero>(context);
                }
                return _genericRepository;
            }
        }

        public IHeroRepository HeroRepository
        {
            get
            {
                if (this.heroRepository == null)
                {
                    this.heroRepository = new HeroRepository(context, _mapper);
                }
                return heroRepository;
            }
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

