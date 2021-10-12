using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teaching.Models;
using Teaching.Models.Enums;

namespace Teaching.InitialData
{
    public static class CarData
    {
        private static readonly List<Car> ListCars = new List<Car>
        {
            new Car { Id = Guid.NewGuid(), Model = CarModels.Toyota },
            new Car { Id = Guid.NewGuid(), Model = CarModels.Mazda }
        };

        public static void SetInitialValues(ModelBuilder builder)
        {
            foreach (var car in ListCars)
                builder.Entity<Car>().HasData(car);
        }
    }
}
