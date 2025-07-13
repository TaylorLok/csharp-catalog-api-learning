namespace Play.Catalog.Service.Settings
{
    public class MongoDBSettings
    {
        public string Host { get; init; } = string.Empty;
        public int Port { get; init; }

        public string ConnectionString => $"mongodb://{Host}:{Port}";
        public string DatabaseName { get; init; } = string.Empty;
    }
}