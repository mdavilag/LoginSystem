using LoginSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginSystemApi.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("text")
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("text")
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("text")
                .HasMaxLength(14);
            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("text")
                .IsRequired();

            builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity(x => x.ToTable("UserRoles"));
        }
    }
}
