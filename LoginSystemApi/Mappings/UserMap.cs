using LoginSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginSystemApi.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("text")
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x=>x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("text")
                .IsRequired()
                .HasMaxLength(16);
        }
    }
}
