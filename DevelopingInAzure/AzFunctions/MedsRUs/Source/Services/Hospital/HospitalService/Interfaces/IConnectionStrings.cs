namespace HospitalService.Interfaces
{

    public interface IConnectionStrings
    {
        string ServiceBusConnectionString { get; }
        
        string SqlServerConnectionString { get; }
    }

}