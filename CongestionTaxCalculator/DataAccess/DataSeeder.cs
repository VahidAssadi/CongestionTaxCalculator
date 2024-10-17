
using CongestionTaxCalculator.DomainModels;

public static class DataSeeder
{
    public static void SeedData()
    {
        var context = DependencyResolver.DbContext;
        TollRecordSeeder(context);
    }
    private static void TollRecordSeeder(CongestionTaxContext context)
    {
        var tollRecords = new List<TollRecord>() {

            new (new Vehicle("REG120913"), new DateTime(2013,01,14,21,00,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,01,15,21,00,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,07,06,23,27)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,07,15,27,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,06,27,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,06,20,27)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,14,35,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,15,29,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,15,47,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,16,01,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,16,48,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,17,49,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,18,29,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,02,08,18,35,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,03,26,17,49,00)),
            new (new Vehicle("REG120913"), new DateTime(2013,03,28,14,07,00)),
        };


        context.TollRecords.AddRange(tollRecords);
        context.SaveChanges();
    }
}