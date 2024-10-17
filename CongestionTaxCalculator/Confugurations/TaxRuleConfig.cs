public class TaxRuleConfig
{
    public TaxExemptionConfig TaxFreeDates { get; set; }
    public int MaximumTaxAmountPerDayAndVehicle { get; set; }
    public int SingleChargeRuleTimeAmount { get; set; }
    public List<TaxAmountTimeRangeConfig> TaxAmountTimeRanges { get; set; }
}
