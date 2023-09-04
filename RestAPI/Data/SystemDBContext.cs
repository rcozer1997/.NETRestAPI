using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestAPI.Data.Map;
using RestAPI.Models;

namespace RestAPI.Data
{
    public class SystemDBContext : IdentityDbContext<UserModel>
    {
        public SystemDBContext(DbContextOptions<SystemDBContext>options) : base(options)
         {

         }
       
        public DbSet<UserModel> Users { get; set; }
        public DbSet<EventsModel> Events { get; set; }
        public DbSet<EventsParticipantsModel> EventsParticipants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EventsMap());
            modelBuilder.ApplyConfiguration(new EventsParticipantsMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
