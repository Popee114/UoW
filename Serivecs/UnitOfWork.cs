using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teaching.DbContexts;
using Teaching.Models;
using Teaching.Repositories;
using Teaching.Repositories.Interfaces;
using Teaching.Serivecs.Interfaces;

namespace Teaching.Serivecs
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<User> _userRepository;
        private IRepository<Car> _carRepository;
        private readonly AccountContext _accountContext;
        private bool disposed;

        public UnitOfWork(AccountContext accountContext,
            IRepository<User> userRepository,
            IRepository<Car> carRepository)
        {
            _accountContext = accountContext;
            _userRepository = userRepository;
            _carRepository = carRepository;
            disposed = false;
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new GenericRepository<User>(_accountContext);
                return _userRepository;
            }
        }
        
        public IRepository<Car> CarRepository
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new GenericRepository<Car>(_accountContext);
                return _carRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _accountContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _accountContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
