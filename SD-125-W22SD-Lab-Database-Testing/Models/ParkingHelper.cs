namespace SD_125_W22SD_Lab_Database_Testing.Models
{
    public class ParkingHelper
    {
        private ParkingContext parkingContext;
        public ParkingHelper(ParkingContext context)
        {
            this.parkingContext = context;
        }

        public Pass CreatePass(string purchaser, bool premium, int capacity)
        {
            Pass newPass = new Pass(purchaser, capacity);
            newPass.Purchaser = purchaser;
            newPass.Premium = premium;
            newPass.Capacity = capacity;
            parkingContext.Passes.Add(newPass);
            parkingContext.SaveChanges();
            return newPass;
        }

        public ParkingSpot CreateParkingSpot()
        {
            ParkingSpot newSpot = new ParkingSpot();
            newSpot.Occupied = false;
            parkingContext.ParkingSpots.Add(newSpot);
            return newSpot;
        }

        public void AddVehicleToPass(string passholderName, string vehicleLicence)
        {
            foreach(Vehicle vehicle in parkingContext.Vehicles)
            {
                if(vehicle.Licence == vehicleLicence)
                {
                    Pass newPass = new Pass(passholderName, 3);
                    parkingContext.Passes.Add(newPass);
                    if (newPass.Capacity.Equals(newPass.Vehicles.Count()))
                    {
                        throw new Exception();
                    }
                }
            }
            if (!parkingContext.Vehicles.Any(v => v.Licence == vehicleLicence))
            {
                throw new Exception();
            }
            
        }
    }
}