using Microsoft.Azure.Cosmos;
using System;
using System.Xml.Linq;

namespace CPOnboardingAPI.Services
{
    public class CosmosDbClient
    {
        private readonly CosmosClient _dbClient;
        private readonly string _dbName;
        private readonly string _containerName;
        public CosmosDbClient(IConfiguration config)
        {
            ArgumentNullException.ThrowIfNull(config);
            _dbName = config["DbConfig:DatabaseName"] ?? string.Empty;
            _containerName = config["DbConfig:ContainerName"] ?? string.Empty;

            _dbClient = new CosmosClient(config.GetConnectionString("CosmosDbConnection"));
        }

        public async Task InitializeDatabaseAsync()
        {

            var result = await _dbClient.CreateDatabaseIfNotExistsAsync(_dbName);
            await result.Database.CreateContainerIfNotExistsAsync(
                _containerName, "/Id"); //ApplicationTemplateId will probably be our partiition for questions.
        }

        public async Task<Container> GetContainer()
        {
            await InitializeDatabaseAsync();
            return _dbClient.GetContainer(_dbName, _containerName);
        }


    }
}
