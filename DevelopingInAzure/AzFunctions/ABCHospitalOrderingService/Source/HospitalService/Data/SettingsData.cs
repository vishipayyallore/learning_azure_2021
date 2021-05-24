using System;

namespace HospitalService.Data
{

    public class SettingsData
    {
        public SettingsData()
        {
            SqlServerConnectionString = Environment
                .GetEnvironmentVariable("ConnectionStrings:SQLAZURECONNSTR_SqlServerConnection", EnvironmentVariableTarget.Process);

            ServiceBusConnectionString = Environment
                .GetEnvironmentVariable("ServiceBusConnection", EnvironmentVariableTarget.Process);
        }


        public string SqlServerConnectionString { get; }

        public string ServiceBusConnectionString { get; }
    }

}
