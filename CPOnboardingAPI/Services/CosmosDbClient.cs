using Microsoft.Azure.Cosmos;
using System;
using System.Xml.Linq;

namespace CPOnboardingAPI.Services
{
    public class CosmosDbClient
    {
        private readonly IConfiguration _config;
        private readonly CosmosClient _dbClient;
        private readonly string _dbName;
        private readonly string _containerName;
        public CosmosDbClient(IConfiguration config)
        {
            _config = config;
            _dbName = _config["DbConfig:DatabaseName"] ?? string.Empty;
            _containerName = _config["DbConfig:ContainerName"] ?? string.Empty;

            _dbClient = new CosmosClient(_config.GetConnectionString("CosmosDbConnection"));
        }

        public async Task InitializeDatabaseAsync()
        {

            var result = await _dbClient.CreateDatabaseIfNotExistsAsync(_dbName);
            await result.Database.CreateContainerIfNotExistsAsync(
                _containerName, "/ApplicationTemplateId"); //ApplicationTemplateId will probably be our partiition for questions.
        }

        public async Task<Container> GetContainer()
        {
            await InitializeDatabaseAsync();
            return _dbClient.GetContainer(_dbName, _containerName);
        }


    }
}
