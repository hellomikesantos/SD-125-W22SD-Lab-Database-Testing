using SD_125_W22SD_Lab_Database_Testing.Models;

namespace SD_125_W22SD_Lab_Database_Testing.DAL
{
    public class ParkingSpotRepository : IRepository<ParkingSpot>
    {
        private ParkingContext _context;
        public ParkingSpotRepository(ParkingContext context)
        {
            _context = context;
        }
        public void Create(ParkingSpot entity)
        {
            _context.ParkingSpots.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(ParkingSpot entity)
        {
            throw new NotImplementedException();
        }

        public ParkingSpot Get(int id)
        {
            throw new NotImplementedException();
        }

        public ParkingSpot Get(Func<ParkingSpot, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<ParkingSpot> GetAll()
        {
            return _context.ParkingSpots.ToList();
        }

        public ICollection<ParkingSpot> GetList(Func<ParkingSpot, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public ParkingSpot Update(ParkingSpot entity)
        {
            throw new NotImplementedException();
        }
    }
}
