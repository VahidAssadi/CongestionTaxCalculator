
public static class DependencyResolver
{
    private static CongestionTaxContext _dbContext;


    public static CongestionTaxContext DbContext
    {
        get
        {
            _dbContext ??= new CongestionTaxContext();
            return _dbContext;
        }
    }
    public static ITollRecordRepository GetTollRecordReositoryRepository()
    {
        return new TollRecordReository(DbContext);
    }
}