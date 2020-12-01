using System;

namespace HomeApp.WebApi.Settings
{
    public class DbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username => Environment.GetEnvironmentVariable("MYSQL_USERNAME");
        public string Password => Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        public string Database { get; set; }

        public override string ToString()
        {
            return $"server={Host};port={Port};user={Username};password={Password};database={Database}";
        }
    }
}