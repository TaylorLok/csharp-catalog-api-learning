using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Play.Catalog.Service.Settings;
using Play.Catalog.Service.Repositories;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB GUID serialization BEFORE building the app
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

// Configure settings from appsettings.json
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection(nameof(MongoDBSettings))
);

builder.Services.Configure<ServiceSettings>(
    builder.Configuration.GetSection(nameof(ServiceSettings))
);

// Register MongoDB database
builder.Services.AddSingleton<IMongoDatabase>(serviceProvider =>
{
    var mongoDbSettings = serviceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

    var serviceSettings = serviceProvider.GetRequiredService<IOptions<ServiceSettings>>().Value;
    return mongoClient.GetDatabase(serviceSettings.ServiceName);
});

// Register repositories
builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false; // This is to avoid the "Async" suffix in action names
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
