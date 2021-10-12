using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teaching.Models;
using Teaching.Repositories.Interfaces;

namespace Teaching.Serivecs.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Car> CarRepository { get; }
        Task SaveAsync();
    }
}
