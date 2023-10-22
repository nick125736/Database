namespace Database.Models
{
    public class DBUtil 
    { 
        private static IConfigurationRoot _configuration;
        private static string? _connectString; private static IConfigurationBuilder builder;
        public static string ConnectionString() 
        {
            builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            _connectString = _configuration.GetConnectionString("CalendarContext");
            return _connectString; 
        } 
    }

}
