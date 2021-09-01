namespace Webshop
{
    public class Settings
    {
        public string EnvironmentString { get; set; }
        public MongoDbSetting MongoDatabase { get; set; }
    }

    public class MongoDbSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}