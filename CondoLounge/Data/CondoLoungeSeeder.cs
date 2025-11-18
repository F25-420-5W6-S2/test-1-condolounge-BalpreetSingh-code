using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data
{
    public class CondoLoungeSeeder
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public CondoLoungeSeeder(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _db = db; 
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task Seed()
        {

            await _db.Database.MigrateAsync();

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
            }

            if (!await _roleManager.RoleExistsAsync("Default"))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Default"));
            }

            var building = await _db.Buildings.FirstOrDefaultAsync();

            if (building == null) 
            {
                building = new Building
                {
                    Name = "Main Tower",
                    Address = "123 example street"
                };
                _db.Buildings.Add(building);
                _db.SaveChanges();
            }

            var condo = await _db.Condos.FirstOrDefaultAsync();
            if (condo == null)
            {
                condo = new Condo
                {
                    BuildingId = building.Id,
                    CondoNumber = "101",
                    Location = "1st Floor"
                };
                _db.Condos.Add(condo);
                _db.SaveChanges();
            }

            if (!_userManager.Users.Any())
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin@condolounge.com",
                    Email = "admin@condolounge.com"
                };
                var result= await _userManager.CreateAsync(admin, "Admin123!");

                if (result.Succeeded)
                {
                    admin.Condos.Add(condo);
                    await _db.SaveChangesAsync();

                    await _userManager.AddToRoleAsync(admin, "Admin");
                    await _userManager.AddToRoleAsync(admin, "Default");

                }
            }
        }
    }
}
