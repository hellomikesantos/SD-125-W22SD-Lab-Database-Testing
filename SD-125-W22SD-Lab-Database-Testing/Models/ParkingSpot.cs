namespace SD_125_W22SD_Lab_Database_Testing.Models
{
    public class ParkingSpot
    {
        public int ID { get; set; }
        public bool Occupied { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
