using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestAPI.Models;

namespace RestAPI.Data.Map
{
    public class EventsParticipantsMap : IEntityTypeConfiguration<EventsParticipantsModel>
    {
        public void Configure(EntityTypeBuilder<EventsParticipantsModel> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Event).WithMany(e => e.Participants).HasForeignKey(e => e.EventId);
            builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
        }
    }
}

