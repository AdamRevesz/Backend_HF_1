using Backend_HF_1.Database;
using Backend_HF_1.Models;

namespace Backend_HF_1.Repository
{
    public class DunaLevelRepository : IDunaLevelRepository
    {
        private readonly DunaLevelDbContext _context;


        public DunaLevelRepository(DunaLevelDbContext ctx)
        {
            this._context = ctx;
        }

        public void Create(DunaLevel entity)
        {
            _context.Set<DunaLevel>().Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<DunaLevel> GetAll()
        {
            return _context.Set<DunaLevel>();
        }


    }
}
