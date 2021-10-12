using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teaching.Models.Interfaces;

namespace Teaching.Models
{
    public class User : Identificator
    {
        public User()
        {
            Cars = new List<Car>();
        }

        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public List<Car> Cars { get; set; }
    }
}
