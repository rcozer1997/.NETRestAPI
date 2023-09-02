using Microsoft.EntityFrameworkCore;
using RestAPI.Data.Map;
using RestAPI.Models;

namespace RestAPI.Data
{
    public class SystemDBContext : DbContext
    {
        public SystemDBContext(DbContextOptions<SystemDBContext>options) : base(options)
         {

         }
       
        public DbSet<UserModel> Users { get; set; }
        public DbSet<EventsModel> Events { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=shared");
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EventsMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
