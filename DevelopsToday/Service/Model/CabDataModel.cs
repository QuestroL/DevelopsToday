using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopsToday.Service.Model
{
    public class CabDataModel
    {
        [Name("VendorID")]
        public int? VendorID { get; set; }
        [Name("tpep_pickup_datetime")]
        public DateTime? TpepPickupDatetime { get; set; }
        [Name("tpep_dropoff_datetime")]
        public DateTime? TpepDropoffDatetime { get; set; }
        [Name("passenger_count")]
        public int? PassengerCount { get; set; }
        [Name("trip_distance")]
        public float? TripDistance { get; set; }
        [Name("RatecodeID")]
        public int? RatecodeID { get; set; }
        [Name("store_and_fwd_flag")]
        public string? StoreAndFwdFlag { get; set; }
        [Name("PULocationID")]
        public int? PULocationID { get; set; }
        [Name("DOLocationID")]
        public int? DOLocationID { get; set; }
        [Name("payment_type")]
        public int? PaymentType { get; set; }
        [Name("fare_amount")] 
        public float? FareAmount { get; set; }
        [Name("extra")] 
        public float? Extra { get; set; }
        [Name("mta_tax")]
        public float? MtaTax { get; set; }
        [Name("tip_amount")]
        public float? TipAmount { get; set; }
        [Name("tolls_amount")]
        public float? TollsAmount { get; set; }
        [Name("improvement_surcharge")]
        public float? ImprovementSurcharge { get; set; }
        [Name("total_amount")]
        public float? TotalAmount { get; set; }
        [Name("congestion_surcharge")]
        public float? CongestionSurcharge { get; set; }
    }
}
