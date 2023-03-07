using BusinessObject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<AspNetUsers>
    {
        public void Configure(EntityTypeBuilder<AspNetUsers> builder)
        {
            var hasher = new PasswordHasher<AspNetUsers>();

            builder.ToTable("Users");

            builder.HasData(
                
                new AspNetUsers
                {
                    Id = "1",
                    Email = "Customer@localhost.com",
                    NormalizedEmail = "CUSTOMER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Customer",
                    UserName = "Customer@localhost.com",
                    NormalizedUserName = "CUSTOMER@LOCALHOST.com",
                    PasswordHash = hasher.HashPassword(null, "P@assword1"),
                    EmailConfirmed = false
                },

                new AspNetUsers
                {
                    Id = "2",
                    Email = "Manager@localhost.com",
                    NormalizedEmail = "MANAGER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Manager",
                    UserName = "manager@localhost.com",
                    NormalizedUserName = "MANAGER@LOCALHOST.com",
                    PasswordHash = hasher.HashPassword(null, "P@assword1"),
                    EmailConfirmed = false
                }
                
                );
        }
    }
}
