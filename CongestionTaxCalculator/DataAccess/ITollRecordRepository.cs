
public interface ITollRecordRepository
{
    IEnumerable<TollRecord> GetTollRecords(string licensePlate, DateTime date);
}