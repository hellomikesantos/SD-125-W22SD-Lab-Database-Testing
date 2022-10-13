﻿namespace SD_125_W22SD_Lab_Database_Testing.Models
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
    }
}