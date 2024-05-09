using DevelopsToday.Service;
using System.Diagnostics;

var csvFilePath = @"C:\Users\DDDeS\OneDrive\Desktop\DevelopsToday\DevelopsToday\Resources\sample-cab-data.csv";

const string connectionString =
    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
var stopwatch = new Stopwatch();

stopwatch.Start();
await AddRecordsService.AddRecords(connectionString, csvFilePath);
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);