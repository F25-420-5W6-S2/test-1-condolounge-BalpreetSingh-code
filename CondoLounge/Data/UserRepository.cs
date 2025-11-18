using CondoLounge.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return _db.Users
                .Include(u => u.Condos)
                .ThenInclude(c => c.Building)
                .ToList();
        }
        
    }
}
