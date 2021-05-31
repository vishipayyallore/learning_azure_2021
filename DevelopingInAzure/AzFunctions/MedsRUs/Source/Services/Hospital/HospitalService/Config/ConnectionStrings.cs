using HospitalService.Interfaces;
using System;

namespace HospitalService.Config
{

    public class ConnectionStrings : IConnectionStrings
    {
        public ConnectionStrings()
        {
            SqlServerConnectionString = Environment
                .GetEnvironmentVariable("SQLAZURECONNSTR_SqlServerConnection", EnvironmentVariableTarget.Process);

            ServiceBusConnectionString = Environment
                .GetEnvironmentVariable("ServiceBusConnection", EnvironmentVariableTarget.Process);
        }


        public string SqlServerConnectionString { get; }

        public string ServiceBusConnectionString { get; }
    }

}
