using LoginSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginSystemApi.Mappings
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(120)")
                .IsRequired()
                .HasMaxLength(120);
            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(80)")
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR(14)")
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
