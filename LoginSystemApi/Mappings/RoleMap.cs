using LoginSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginSystemApi.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Role)
                .HasColumnName("Role")
                .HasColumnType("integer")
                .IsRequired();
        }
    }
}
