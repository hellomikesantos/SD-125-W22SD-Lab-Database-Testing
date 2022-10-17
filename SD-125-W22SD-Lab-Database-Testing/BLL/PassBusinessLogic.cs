using SD_125_W22SD_Lab_Database_Testing.DAL;
using SD_125_W22SD_Lab_Database_Testing.Models;

namespace SD_125_W22SD_Lab_Database_Testing.BLL
{
    public class PassBusinessLogic
    {
        private IRepository<Pass> passRepo;
        private IRepository<ParkingSpot> parkingSpotRepo;

        public PassBusinessLogic(IRepository<Pass> repo, IRepository<ParkingSpot> parkingSpotRepo)
        {
            this.passRepo = repo;
            this.parkingSpotRepo = parkingSpotRepo;


        }

        public ICollection<Pass> GetAllPasses()
        {
            return passRepo.GetAll().ToList();
        }

        public ICollection<ParkingSpot> GetAllParkingSpots()
        {
            return parkingSpotRepo.GetAll().ToList();
        }

        public void CreatePass(string purchaser, int capacity)
        {
            if(purchaser.Length >= 3 && purchaser.Length <= 20 
                 && capacity >= 0)
            {
                Pass pass = new Pass(purchaser, capacity);
                passRepo.Create(pass);
                passRepo.Save();
            }
            else
            {
                throw new Exception();
            }   
        }

        public void CreateParkingSpot()
        {
            ParkingSpot parkingSpot = new ParkingSpot();
            parkingSpotRepo.Create(parkingSpot);
            parkingSpotRepo.Save();
        }
    }
}
