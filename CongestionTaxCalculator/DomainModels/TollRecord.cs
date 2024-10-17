using CongestionTaxCalculator.DomainModels;

public class TollRecord
{
    private TollRecord() { }
    public TollRecord(Vehicle vehicle, DateTime passThroughTime)
    {
        Id = Guid.NewGuid();
        Vehicle = vehicle;
        PassThroughTime = passThroughTime;
    }

    public Guid Id { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public DateTime PassThroughTime { get; private set; }

}
