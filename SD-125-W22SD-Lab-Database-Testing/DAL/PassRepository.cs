using SD_125_W22SD_Lab_Database_Testing.Models;

namespace SD_125_W22SD_Lab_Database_Testing.DAL
{
    public class PassRepository : IRepository<Pass>
    {
        private ParkingContext _context;
        public PassRepository(ParkingContext context)
        {
            _context = context;
        }
        public void Create(Pass entity)
        {
            _context.Passes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Pass entity)
        {
            throw new NotImplementedException();
        }

        public Pass Get(int id)
        {
            throw new NotImplementedException();
        }

        public Pass Get(Func<Pass, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pass> GetAll()
        {
            return _context.Passes.ToList();
        }

        public ICollection<Pass> GetList(Func<Pass, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Pass Update(Pass entity)
        {
            throw new NotImplementedException();
        }
    }
}
