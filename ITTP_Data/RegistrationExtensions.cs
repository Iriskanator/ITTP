using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTP_Data
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            services.AddDbContext<UserContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            MigrationHelper.CreateDatabase(builder.UseSqlite(configuration.GetConnectionString("DefaultConnection")).Options);

            return services;
        }
    }
}
