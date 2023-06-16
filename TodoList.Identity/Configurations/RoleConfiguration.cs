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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    //Id = "e04d3eab-d53b-447e-a78a-d561caa47719",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    //Id = "b64f5fed-2404-416b-86bd-f998bdd2d586",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }
    }
}
