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

            var mockDbSet = new Mock<DbSet<Pass>>();

            mockDbSet.As<IQueryable<Pass>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<Pass>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<Pass>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<Pass>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mockDbSetForParkingSpot = new Mock<DbSet<ParkingSpot>>();

            mockDbSetForParkingSpot.As<IQueryable<ParkingSpot>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSetForParkingSpot.As<IQueryable<ParkingSpot>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSetForParkingSpot.As<IQueryable<ParkingSpot>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSetForParkingSpot.As<IQueryable<ParkingSpot>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            var mockContext = new Mock<ParkingContext>();
            mockContext.Setup(m => m.Passes).Returns(mockDbSet.Object);
            mockContext.Setup(m => m.ParkingSpots).Returns(mockDbSetForParkingSpot.Object);

            PassBusinessLogic = new PassBusinessLogic(new PassRepository(mockContext.Object),
                new ParkingSpotRepository(mockContext.Object));
        }
        [TestMethod]
        public void CreateNewPass()
        {
            // arrange
            List<Pass> assertedPasses = new List<Pass>();

            // act
            assertedPasses.Add(new Pass("Michael", 2));

            // assert
            Assert.AreEqual(assertedPasses.Count(),
                PassBusinessLogic.GetAllPasses().Count());
        }

        [TestMethod]
        public void CreateNewPass_IfPurchaserArgumentIsNotBetween3And20Characters()
        {
            // arrange
            List<Pass> assertedPasses = new List<Pass>();

            // act
            assertedPasses.Add(new Pass("M", 2));

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

            // act
            assertedParkingSpots.Add(new ParkingSpot());

            // assert
            Assert.AreEqual(assertedParkingSpots.Count(),
                PassBusinessLogic.GetAllParkingSpots().Count());
        }
    }
}