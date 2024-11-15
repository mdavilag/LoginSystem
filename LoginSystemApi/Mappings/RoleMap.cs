using LoginSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginSystemApi.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        { 
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

        }
    }
}
