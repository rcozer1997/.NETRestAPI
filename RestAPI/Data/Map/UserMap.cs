using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestAPI.Models;
using System.Text.RegularExpressions;

namespace RestAPI.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Ignore(x => x.PhoneNumber);
            builder.Ignore(x => x.PhoneNumberConfirmed);
            builder.Ignore(x => x.UserName);
            builder.Ignore(x => x.NormalizedUserName);
            builder.Ignore(x => x.NormalizedEmail);
            builder.Ignore(x => x.EmailConfirmed);
            builder.Ignore(x => x.SecurityStamp);
            builder.Ignore(x => x.ConcurrencyStamp);
            builder.Ignore(x => x.TwoFactorEnabled);
            builder.Ignore(x => x.LockoutEnd);
            builder.Ignore(x => x.LockoutEnabled);
            builder.Ignore(x => x.AccessFailedCount);
        }
    }
}
