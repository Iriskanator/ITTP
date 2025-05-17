using ITTP_Domain;
using Microsoft.EntityFrameworkCore;

namespace ITTP_Data
{
    public static class MigrationHelper
    {
        public static bool DatabaseExist(DbContextOptions options)
        {
            using UserContext userContext = new UserContext(options);
            return userContext.Database.CanConnect();
        }

        public static bool MigrationsExist(DbContextOptions options)
        {
            using UserContext userContext = new UserContext(options);
            return userContext.Database.GetMigrations().Count() > 0;
        }

        public static void CreateDatabase(DbContextOptions options)
        {
            using UserContext userContext = new UserContext(options);
            if(userContext.Database.EnsureCreated())
            {
                userContext.Users.Add(new User()
                {
                    Admin = true,
                    Name = "Admin",
                    Login = "Admin",
                    Password = "Admin",
                    ModifiedBy = "",
                    ModifiedOn = DateTime.UtcNow,
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.UtcNow,
                    RevokedBy = "",
                    RevokedOn = null,
                    Birthday = null,
                    Gender = 2,
                    Guid = Guid.NewGuid(),
                });
                userContext.SaveChanges();
            }

        }
    }
}
