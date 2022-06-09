using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTemplate.Api.Models;

namespace WebApiTemplate.Api.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Id, "IX_Product_Name").IsUnique();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("First_Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(10);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("Last_Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(10);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnName("Phone_Number")
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);
        }
    }
}
