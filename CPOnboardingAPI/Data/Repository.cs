using CPOnboardingAPI.Models;
using Microsoft.Azure.Cosmos;

namespace CPOnboardingAPI.Data
{
    public class Repository : IRepository
    {
        private readonly Container _container;

        public Repository(CosmosClient client, string dbName, string containerName)
        {
            ArgumentNullException.ThrowIfNull(client);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(dbName);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(containerName);
            _container = client.GetContainer(dbName, containerName);

        }

        public async Task<ApplicationTemplate> CreateTemplate(ApplicationTemplate applicationTemplate)
        {
            var result = await _container.CreateItemAsync(applicationTemplate,
                new PartitionKey(applicationTemplate.Id));

            return result;
        }

        public async Task DeleteTemplate(string id)
        {
            await _container.DeleteItemAsync<ApplicationTemplate>(id, new PartitionKey(id));
        }

        public async Task<IEnumerable<ApplicationTemplate>> GetAllTemplates()
        {
            var query = _container.GetItemQueryIterator<ApplicationTemplate>(new QueryDefinition("SELECT * FROM c"));
            var results = new List<ApplicationTemplate>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<ApplicationTemplate> GetTemplateById(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<ApplicationTemplate>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<ApplicationTemplate> UpdateTemplate(string id, ApplicationTemplate applicationTemplate)
        {
            var response = await _container.UpsertItemAsync(applicationTemplate, new PartitionKey(id));
            return response.Resource;
        }
    }
}
