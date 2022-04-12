using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "@dbo");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName).HasColumnName("UserName").HasMaxLength(50).IsRequired();

            builder.Property(u => u.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();

            builder.Property(u => u.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();

            builder.Property(u => u.Password).HasColumnName("Password").HasMaxLength(20).IsRequired();

            builder.Property(u => u.Gender).HasColumnName("Gender").IsRequired();

            builder.Property(u => u.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();

            builder.Property(u => u.CreatedDate).HasDefaultValue(DateTime.Now);

            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Furkan",
                LastName = "Altıntaş",
                Password = "12345",
                Gender = true,
                DateOfBirth = DateTime.Parse("03-11-2000"),
                CreatedDate = DateTime.Now,
                Address = "İstanbul/Pendik",
                Email = "furkanaltintas785@gmail.com",
                UserName = "furkanaltintas",
                CreatedUserId = 1,
                UpdatedUserId = 1,
                UpdatedDate = DateTime.Now
            });
        }
    }
}