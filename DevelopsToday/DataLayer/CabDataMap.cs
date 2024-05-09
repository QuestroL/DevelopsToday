using DevelopsToday.DataLayer.Entity;
using DevelopsToday.Service.Model;

namespace DevelopsToday.DataLayer
{
    public static class CabDataMap
    {
        public static List<CabData> MapModel(this List<CabDataModel> model)
        {
            List<CabData> result = new List<CabData>();
            foreach (var item in model)
            {
                result.Add(item.MapModel());
            }

            return result;
        }

        public static CabData MapModel(this CabDataModel model)
        {
            return new CabData()
            {
                TpepPickupDatetime = model.TpepPickupDatetime.Value,
                TpepDropoffDatetime = model.TpepDropoffDatetime.Value,
                PassengerCount = model.PassengerCount,
                TripDistance = model.TripDistance,
                StoreAndFwdFlag = model.StoreAndFwdFlag == "N" ? "No" : "Yes",
                PULocationID = model.PULocationID,
                DOLocationID = model.DOLocationID,
                FareAmount = model.FareAmount,
                TipAmount = model.TipAmount
            };
        }
    }
}
