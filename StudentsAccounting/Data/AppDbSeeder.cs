using Microsoft.AspNetCore.Identity;
using StudentsAccounting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAccounting.Data
{
    public class AppDbSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AppDbSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedData()
        {
            await SeedRoles(roleManager);
            await SeedAdminUser(userManager);
        }

        public async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (! await roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };

                await roleManager.CreateAsync(adminRole);
            }

            if (! await roleManager.RoleExistsAsync("Student"))
            {
                var studentRole = new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "Student".ToUpper()
                };

                await roleManager.CreateAsync(studentRole);
            }
        }

        public async Task SeedAdminUser(UserManager<User> userManager)
        {
            if (await userManager.FindByEmailAsync("turchyn_ak17@nuwm.edu.ua") == null)
            {
                var admin = new User
                {
                    UserName = "turchyn_ak17@nuwm.edu.ua",
                    Email = "turchyn_ak17@nuwm.edu.ua",
                    FirstName = "Denys",
                    LastName = "gfhnf"
                };

                var result = await userManager.CreateAsync(admin, "Password123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }

            }
        }
    }
}
