public class TaxExemptionConfig
{
    public List<DateTime> Holidays { get; set; }
    public bool ConsiderDayBeforeHoliday { get; set; }
    public List<string> WeekendDays { get; set; }
    public List<int> ExemptMonths { get; set; }
}
