using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            //builder.HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "e04d3eab-d53b-447e-a78a-d561caa47719",
            //        UserId = "ecf16303-535a-4090-b1d0-f25acc9cb105",
            //    },
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "b64f5fed-2404-416b-86bd-f998bdd2d586",
            //        UserId = "fa9daee8-9c26-4f03-ae00-138890929144",
            //    }
            //    );
        }
    }
}
