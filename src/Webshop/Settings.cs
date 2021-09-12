namespace Webshop
{
    public class Settings
    {
        public string EnvironmentString { get; set; }
        public MongoDbSetting MongoDatabase { get; set; }
        public JwtSettings JwtConfig { get; set; }
    }

    public class MongoDbSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
    }
}