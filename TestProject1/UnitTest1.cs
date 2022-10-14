using Microsoft.EntityFrameworkCore;
using Moq;
using SD_125_W22SD_Lab_Database_Testing.BLL;
using SD_125_W22SD_Lab_Database_Testing.DAL;
using SD_125_W22SD_Lab_Database_Testing.Models;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private PassBusinessLogic PassBusinessLogic;
        public UnitTest1()
        {
            // mock data
            var passesData = new List<Pass>
            {
                new Pass("Michael", 3) {ID = 1},
                new Pass("Michael", 3) {ID = 2},
                new Pass("Michael", 3) {ID = 3},
                new Pass("Michael", 3) {ID = 4},
                new Pass("Michael", 3) {ID = 5},
            }.AsQueryable();

            var parkingSpotsData = new List<ParkingSpot>
            {
                new ParkingSpot{ID = 1},
                new ParkingSpot{ID = 2},
                new ParkingSpot{ID = 3},
                new ParkingSpot{ID = 4},
                new ParkingSpot{ID = 5},
            }.AsQueryable();

            var reservationData = new List<Reservation>
            {
                new Reservation{ID = 1},
                new Reservation{ID = 2},
                new Reservation{ID = 3},
                new Reservation{ID = 4},
                new Reservation{ID = 5},
            }.AsQueryable();

            var vehicleData = new List<Vehicle>
            {
                new Vehicle{ID = 1},
                new Vehicle{ID = 2},
                new Vehicle{ID = 3},
                new Vehicle{ID = 4},
                new Vehicle{ID = 5},
            }.AsQueryable();


            // mock DbSets
            var mockDbSet = new Mock<DbSet<Pass>>();
            mockDbSet.As<IQueryable<Pass>>().Setup(m => m.Provider).Returns(passesData.Provider);
            mockDbSet.As<IQueryable<Pass>>().Setup(m => m.Expression).Returns(passesData.Expression);
            mockDbSet.As<IQueryable<Pass>>().Setup(m => m.ElementType).Returns(passesData.ElementType);
            mockDbSet.As<IQueryable<Pass>>().Setup(m => m.GetEnumerator()).Returns(passesData.GetEnumerator);

            var mockDbSetForParkingSpot = new Mock<DbSet<ParkingSpot>>();
            mockDbSetForParkingSpot.As<IQueryable<ParkingSpot>>().Setup(m => m.Provider).Returns(parkingSpotsData.Provider);
            mockDbSetForParkingSpot.As<IQueryable<ParkingSpot>>().Setup(m => m.Expression).Returns(parkingSpotsData.Expression);
            mockDbSetForParkingSpot.As<IQueryable<ParkingSpot>>().Setup(m => m.ElementType).Returns(parkingSpotsData.ElementType);
            mockDbSetForParkingSpot.As<IQueryable<ParkingSpot>>().Setup(m => m.GetEnumerator()).Returns(parkingSpotsData.GetEnumerator);

            var mockDbSetForReservation = new Mock<DbSet<Reservation>>();
            mockDbSetForReservation.As<IQueryable<Reservation>>().Setup(m => m.Provider).Returns(reservationData.Provider);
            mockDbSetForReservation.As<IQueryable<Reservation>>().Setup(m => m.Expression).Returns(reservationData.Expression);
            mockDbSetForReservation.As<IQueryable<Reservation>>().Setup(m => m.ElementType).Returns(reservationData.ElementType);
            mockDbSetForReservation.As<IQueryable<Reservation>>().Setup(m => m.GetEnumerator()).Returns(reservationData.GetEnumerator);

            var mockDbSetForVehicle = new Mock<DbSet<Vehicle>>();
            mockDbSetForVehicle.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(vehicleData.Provider);
            mockDbSetForVehicle.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(vehicleData.Expression);
            mockDbSetForVehicle.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(vehicleData.ElementType);
            mockDbSetForVehicle.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(vehicleData.GetEnumerator);

            // mock context setups
            var mockContext = new Mock<ParkingContext>();
            mockContext.Setup(m => m.Passes).Returns(mockDbSet.Object);
            mockContext.Setup(m => m.ParkingSpots).Returns(mockDbSetForParkingSpot.Object);
            mockContext.Setup(m => m.Reservations).Returns(mockDbSetForReservation.Object);
            mockContext.Setup(m => m.Vehicles).Returns(mockDbSetForVehicle.Object);

            PassBusinessLogic = new PassBusinessLogic(new PassRepository(mockContext.Object),
                new ParkingSpotRepository(mockContext.Object));
        }
        [TestMethod]
        public void CreateNewPass()
        {
            // arrange
            List<Pass> assertedPasses = new List<Pass>();
            assertedPasses.Add(new Pass("Michael", 2));
            assertedPasses.Add(new Pass("Michael", 2));
            assertedPasses.Add(new Pass("Michael", 2));
            assertedPasses.Add(new Pass("Michael", 2));
            assertedPasses.Add(new Pass("Michael", 2));
            assertedPasses.Add(new Pass("Michael", 2));
            // act
            PassBusinessLogic.CreatePass("Michael", 2);

            // assert
            Assert.AreEqual(assertedPasses.Count(),
                PassBusinessLogic.GetAllPasses().Count());
        }

        [TestMethod]
        public void CreateNewPass_IfPurchaserArgumentIsNotBetween3And20Characters()
        {
            // arrange
            List<Pass> assertedPasses = new List<Pass>();
            assertedPasses.Add(new Pass("M", 2));

            // act
            // assert
            Assert.ThrowsException<Exception>(() =>
            {
                PassBusinessLogic.GetAllPasses().Add(new Pass("M", 2));
            });
        }

        [TestMethod]
        public void CreateNewParkingSpot()
        {
            // arrange
            List<ParkingSpot> assertedParkingSpots = new List<ParkingSpot>();
            assertedParkingSpots.Add(new ParkingSpot());
            assertedParkingSpots.Add(new ParkingSpot());
            assertedParkingSpots.Add(new ParkingSpot());
            assertedParkingSpots.Add(new ParkingSpot());
            assertedParkingSpots.Add(new ParkingSpot());
            assertedParkingSpots.Add(new ParkingSpot());

            // act
            PassBusinessLogic.CreateParkingSpot();

            // assert
            Assert.AreEqual(assertedParkingSpots.Count(),
                PassBusinessLogic.GetAllParkingSpots().Count());
        }
    }
}