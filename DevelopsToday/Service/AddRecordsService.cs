using CsvHelper;
using DevelopsToday.DataLayer;
using DevelopsToday.Service.Model;
using System.Diagnostics;
using System.Globalization;

namespace DevelopsToday.Service
{
    public static class AddRecordsService
    {
        public static async Task AddRecords(string connectionString, string filePath)
        {
            if (string.IsNullOrEmpty(connectionString) && string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException($"connectionString or filePath can not be null.");
            }

            var cabModelModel = new List<CabDataModel>();
            
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                cabModelModel =  csv.GetRecords<CabDataModel>().ToList();
            }

            if (cabModelModel != null && cabModelModel.Any())
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var result = ValidateData(cabModelModel).MapModel();
                stopwatch.Stop();

                Console.WriteLine($"Validation {stopwatch.ElapsedMilliseconds}" );
                using (var dbContext = new DataContext(connectionString))
                {
                    dbContext.Database.EnsureCreated();
                    dbContext.BulkInsert(result);
                }
            }
        }

        private static  List<CabDataModel> ValidateData(List<CabDataModel> recordsModel)
        {
            List <CabDataModel> validatedRecords = new List<CabDataModel>();
            HashSet<(DateTime?,DateTime?, int?)> usedRecords = new HashSet<(DateTime?, DateTime?, int?)>(); // `pickup_datetime`, `dropoff_datetime`,  `passenger_count`
            List<CabDataModel> duplicateRecords = new List<CabDataModel>();
            foreach (var item in recordsModel) 
            {
                if(usedRecords.Contains(new (item.TpepPickupDatetime, item.TpepDropoffDatetime, item.PassengerCount)))
                {
                    duplicateRecords.Add(item);
                }
                else
                {
                    usedRecords.Add(new(item.TpepPickupDatetime, item.TpepDropoffDatetime, item.PassengerCount));
                    
                    if (item.TpepPickupDatetime != null && item.TpepDropoffDatetime != null)
                    {
                        if (!string.IsNullOrEmpty(item.StoreAndFwdFlag))
                        {
                            item.StoreAndFwdFlag = item.StoreAndFwdFlag.TrimStart().TrimEnd();
                        }
                        validatedRecords.Add(item);
                    }
                }
            }

            if (duplicateRecords.Any())
            {
                using (var sWriter = new StreamWriter(@"C:\Users\DDDeS\OneDrive\Desktop\DevelopsToday\DevelopsToday\Resources\duplicates.csv"))
                using (var csvWriter = new CsvWriter(sWriter, CultureInfo.InvariantCulture))
                {
                   csvWriter.WriteRecordsAsync(duplicateRecords);
                }
            }

            return validatedRecords;
        }
    }
}
