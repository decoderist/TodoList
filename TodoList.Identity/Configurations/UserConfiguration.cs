using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Models.Identity;

namespace TodoList.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    //Id = "ecf16303-535a-4090-b1d0-f25acc9cb105",
                    Email = "user@email.com",
                    NormalizedEmail = "USER@EMAIL.COM",
                    FirstName = "User",
                    LastName = "UserFamily",
                    UserName = "UserName",
                    NormalizedUserName = "USERNAME",
                    PasswordHash = hasher.HashPassword(null, "Passw0rd"),
                    EmailConfirmed = true
                },
                 new ApplicationUser
                 {
                     //Id = "fa9daee8-9c26-4f03-ae00-138890929144",
                     Email = "admin@email.com",
                     NormalizedEmail = "ADMIN@EMAIL>COM",
                     FirstName = "Admin",
                     LastName = "AdminFamily",
                     UserName = "AdminName",
                     NormalizedUserName = "ADMINNAME",
                     PasswordHash = hasher.HashPassword(null, "Passw0rd"),
                     EmailConfirmed = true
                 }
                );
        }
    }
}
