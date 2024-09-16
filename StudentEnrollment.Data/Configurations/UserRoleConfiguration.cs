using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data.Configurations
{
    public  class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "d1b5952a-2162-46c7-b29e-1a2a68922c14",
                    UserId = "408aa945-3d84-4421-8342-7269ec64d949",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "d1b5952a-2162-46c7-b29e-1a2a68922c14",
                    UserId = "408aa945-3d84-4421-8342-7269ec64d949",
                }
            );
        }
    }
}
