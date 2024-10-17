

using System.Text.Json;

DataSeeder.SeedData();

var repo = DependencyResolver.GetTollRecordReositoryRepository();


// list of recorded toll per a license plate per day
var tollRecords = repo.GetTollRecords("REG120913", new DateTime(2013, 02, 08, 16, 48, 00));

var vehicle = tollRecords.First().Vehicle;
var config = LoadTaxConfig("Gothenburg");
var model = new CongestionTaxCalculatorService(config);

var dailyEntries = tollRecords.Select(p => p.PassThroughTime).ToList();

var tax = model.GetTax(vehicle, dailyEntries);

Console.WriteLine($" Tax amount: {tax}");




static CityConfiguration LoadTaxConfig(string city)
{
    string baseDirectory = AppContext.BaseDirectory;
    string projectRoot = Directory.GetParent(Directory.GetParent(baseDirectory).Parent.Parent.FullName).FullName;
    string filePath = Path.Combine(projectRoot, "appsettings.json");
    string fileContent = string.Empty;
    if (File.Exists(filePath))
    {
        fileContent = File.ReadAllText(filePath);
    }
    var model = JsonSerializer.Deserialize<TaxConfigurations>(fileContent);
    return model.Cities.Where(p=>p.Name == city).First();
}