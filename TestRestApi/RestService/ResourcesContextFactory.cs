
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace RestService
{
    public class ResourcesContextFactory : IDesignTimeDbContextFactory<ResourcesContext>
    {
        public ResourcesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ResourcesContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TestRestApiDBConnection"));
            return new ResourcesContext(optionsBuilder.Options);
        }
    }
}
