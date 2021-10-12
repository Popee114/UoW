using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teaching.Models;

namespace Teaching.InitialData
{
    public static class UserData
    {
        private static readonly List<User> ListUsers = new List<User>
        {
            new User { Id = Guid.NewGuid(), Login = "Pol", Password = "qwe123" }
        };

        public static void SetInitialValues(ModelBuilder builder)
        {
            foreach (var user in ListUsers)
                builder.Entity<User>().HasData(user);
        }
    }
}
