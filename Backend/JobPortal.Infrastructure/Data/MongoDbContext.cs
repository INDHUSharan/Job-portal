
using Microsoft.Extensions.Options;                                        //appsettings.json la irukkura settings-a read panna use pannuvom.
using MongoDB.Driver;                                                      //mongo db library 
using JobPortal.Infrastructure.Settings;
namespace JobPortal.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;                               //variable to store database connection

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);       //creating connection with mongodb atlas

        _database = client.GetDatabase(settings.Value.DatabaseName);        // creating database 
    }

    public IMongoDatabase Database => _database;                             // property to return database 
}