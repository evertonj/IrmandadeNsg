using IrmandadeNsg.Domain.Models;
using IrmandadeNsg.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace IrmandadeNsg.Infra.Data.Context
{
    public class IrmandadeContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public IrmandadeContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public virtual DbSet<MainComment> MainComments { get; set; }
        public virtual DbSet<SubComment> SubComments { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
