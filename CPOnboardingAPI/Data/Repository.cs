using CPOnboardingAPI.Models;
using CPOnboardingAPI.Services;
using Microsoft.Azure.Cosmos;

namespace CPOnboardingAPI.Data
{
    public class Repository : IRepository
    {
        private readonly CosmosDbClient _client;

        public Repository(CosmosDbClient client)
        {
            _client = client;
        }

        public async Task<ApplicationTemplate> CreateTemplate(ApplicationTemplate applicationTemplate)
        {
            var container = await _client.GetContainer();
            var result = await container.CreateItemAsync(applicationTemplate,
                new PartitionKey(applicationTemplate.Id));

            return result;
        }

        public async Task DeleteTemplate(string id)
        {
            var container = await _client.GetContainer();
            await container.DeleteItemAsync<ApplicationTemplate>(id, new PartitionKey(id));
        }

        public async Task<IEnumerable<ApplicationTemplate>> GetAllTemplates()
        {
            var container = await _client.GetContainer();
            var query = container.GetItemQueryIterator<ApplicationTemplate>(new QueryDefinition("SELECT * FROM c"));
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
                var container = await _client.GetContainer();
                var response = await container.ReadItemAsync<ApplicationTemplate>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<ApplicationTemplate> UpdateTemplate(string id, ApplicationTemplate applicationTemplate)
        {
            var container = await _client.GetContainer();
            var response = await container.UpsertItemAsync(applicationTemplate, new PartitionKey(id));
            return response.Resource;
        }
    }
}
