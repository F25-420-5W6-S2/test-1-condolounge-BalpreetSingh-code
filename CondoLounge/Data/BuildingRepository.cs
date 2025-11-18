using CondoLounge.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data
{
    public class BuildingRepository
    {
        private readonly ApplicationDbContext _db;

        public BuildingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Building> GetAll()
        {
            return _db.Buildings
                .Include(b => b.Condos)
                .ToList();
        }

        public IEnumerable<Condo> GetCondosForBuilding(int buildingId)
        {
            return _db.Condos
                .Where(c => c.BuildingId == buildingId)
                .ToList();
        }

        public IEnumerable<ApplicationUser> GetUsersForBuilding(int buildingId)
        {
            return _db.Condos
                .Where(c => c.BuildingId == buildingId)
                .Include(c => c.Users)
                .SelectMany(c => c.Users)
                .Distinct()
                .ToList();

        }
    }
}


