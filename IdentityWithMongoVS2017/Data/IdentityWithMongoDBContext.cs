using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWithMongoVS2017.Data
{
    public class IdentityWithMongoDBContext
    {
        private MongoClient _dbClient;
        private string _connectionString;
        private IConfigurationRoot _config;

        public IdentityWithMongoDBContext(
            IConfigurationRoot config
            )
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
            _dbClient = _dbClient ?? new MongoClient(_connectionString);
        }

        public IMongoDatabase GetDatabase() => _dbClient.GetDatabase(_config["DBInfo:DBName"]);

        public IMongoCollection<Person> PersonCollection => GetDatabase().GetCollection<Person>(_config["DBInfo:PersonCollection"]);
    }
}
