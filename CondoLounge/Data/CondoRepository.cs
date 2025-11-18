using CondoLounge.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace CondoLounge.Data
{
    public class CondoRepository
    {
        private readonly ApplicationDbContext _db;

        public CondoRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Condo> GetAll()
        {
            return _db.Condos
                .Include(c => c.Building)
                .ToList();
        }
    }
}
