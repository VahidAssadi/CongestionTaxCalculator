using CongestionTaxCalculator.DomainModels;

public class CongestionTaxCalculatorService
{

    private readonly CityConfiguration _cityTaxConfig;
    public CongestionTaxCalculatorService(CityConfiguration taxConfiguration)
    {
        _cityTaxConfig = taxConfiguration;
    }

    /// <summary>
    /// calculate tax for vehicle per date
    /// </summary>
    /// <param name="licensePlate"></param>
    /// <param name="taxDate"></param>
    /// <returns></returns>
    public int GetTax(Vehicle vehicle, List<DateTime> taxDate)
    {
        if (taxDate.Count <= 0)
        {
            return 0;
        }

        DateTime? lastEntryTime = null;

        int dailyTax = 0;
        int maxCharge = 0;

        foreach (var date in taxDate)
        {
            int charge = GetTollFee(date, vehicle);

            if (lastEntryTime.HasValue &&
                (date - lastEntryTime.Value).TotalMinutes <= _cityTaxConfig.TaxRule.SingleChargeRuleTimeAmount)
            {
                maxCharge = Math.Max(maxCharge, charge);
            }
            else
            {
                dailyTax += maxCharge;
                maxCharge = charge;
            }

            lastEntryTime = date;
        }
        if (dailyTax > _cityTaxConfig.TaxRule.MaximumTaxAmountPerDayAndVehicle) { dailyTax = _cityTaxConfig.TaxRule.MaximumTaxAmountPerDayAndVehicle; }

        return dailyTax;
    }
    private int GetTollFee(DateTime date, Vehicle vehicle)
    {
        if (IsTollFreeDate(date) || vehicle.IsTollFreeVehicle()) return 0;

        var tollFees = _cityTaxConfig.TaxRule.TaxAmountTimeRanges.ToList();

        var result = tollFees.FirstOrDefault(p => TimeSpan.Parse(p.StartTime) <= date.TimeOfDay && TimeSpan.Parse(p.EndTime) >= date.TimeOfDay);

        return result?.Amount ?? 0;
    }


    private bool IsTollFreeDate(DateTime date)
    {
        var _taxFreeDates = _cityTaxConfig.TaxRule.TaxFreeDates;

        if (_taxFreeDates.Holidays.Contains(date.Date))
            return true;
        if (_taxFreeDates.ConsiderDayBeforeHoliday && _taxFreeDates.Holidays.Contains(date.Date.AddDays(1)))
            return true;
        if (_taxFreeDates.WeekendDays.Contains(date.DayOfWeek.ToString()))
            return true;
        if (_taxFreeDates.ExemptMonths.Contains(date.Month))
            return true;

        return false;
    }
}
