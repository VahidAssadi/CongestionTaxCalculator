public class TollRecordReository : ITollRecordRepository
{
    private readonly CongestionTaxContext _context;

    public TollRecordReository(CongestionTaxContext context)
    {

        _context = context;

    }
    public IEnumerable<TollRecord> GetTollRecords(string licensePlate, DateTime date)
    {
        return _context.TollRecords.Where(p => p.Vehicle.LicencePlate == licensePlate && p.PassThroughTime.Date == date.Date).ToList();
    }
}
