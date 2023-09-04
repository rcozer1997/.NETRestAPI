using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestAPI.Models;

namespace RestAPI.Data.Map
{
    public class EventsMap : IEntityTypeConfiguration<EventsModel>
    {
        public void Configure(EntityTypeBuilder<EventsModel> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired();
            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.ResponsibleId);
            builder.HasOne(e => e.Responsible);
        }
    }
}
