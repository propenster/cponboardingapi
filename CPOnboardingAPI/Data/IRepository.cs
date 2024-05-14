using CPOnboardingAPI.Models;

namespace CPOnboardingAPI.Data
{
    public interface IRepository
    {
        Task<ApplicationTemplate> CreateTemplate(ApplicationTemplate applicationTemplate);
        Task<IEnumerable<ApplicationTemplate>> GetAllTemplates();
        Task<ApplicationTemplate> GetTemplateById(string id);
        Task<ApplicationTemplate> UpdateTemplate(string id,  ApplicationTemplate applicationTemplate);
        Task DeleteTemplate(string id);


    }
}
