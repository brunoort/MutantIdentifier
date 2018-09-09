using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MutantIdentifier.ContextDatabase;
using System.IO;

namespace MutantIdentifier
{
    public class Context : IDesignTimeDbContextFactory<MutantContext>
    {
        public MutantContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MutantContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new MutantContext(builder.Options);
        }
    }
}
