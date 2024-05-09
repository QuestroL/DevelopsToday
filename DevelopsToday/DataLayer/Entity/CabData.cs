namespace DevelopsToday.DataLayer.Entity
{
    public class CabData
    {
        public int Id { get; set; }
        public DateTime TpepPickUpDateTime { get; set; }
        public DateTime TpepDropOffDateTime { get; set; }
        public int? PassengerCount { get; set; }
        public float? TripDistance { get; set; }
        public string? StoreAndFwdFlag { get; set; }
        public int? PULocationID { get; set; }
        public int? DOLocationID { get; set; }
        public float? FareAmount { get; set; }
        public float? TipAmount { get; set; }
    }
}
