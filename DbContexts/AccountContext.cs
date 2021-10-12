using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using Teaching.InitialData;
using Teaching.Models;

namespace Teaching.DbContexts
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            GenereteGuid(builder);
            UserData.SetInitialValues(builder);
            CarData.SetInitialValues(builder);
        }

        private void GenereteGuid(ModelBuilder builder)
        {
            // Автогенерация идентификатора для моделей.
            var keysProperties = builder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
                property.ValueGenerated = ValueGenerated.OnAdd;
        }
    }
}
