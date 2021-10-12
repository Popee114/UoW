using System;
using System.Collections.Generic;
using Teaching.Models.Enums;
using Teaching.Models.Interfaces;

namespace Teaching.Models
{
    public class Car: Identificator
    {
        public Car()
        {
            Users = new List<User>();
        }

        public Guid Id { get; set; }

        public CarModels Model { get; set; }

        public List<User> Users { get; set; }
    }
}
