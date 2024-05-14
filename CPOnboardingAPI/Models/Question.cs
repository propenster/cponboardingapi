using System.ComponentModel.DataAnnotations;

namespace CPOnboardingAPI.Models
{
    public class Question : BaseEntity, IBaseQuestion
    {
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty ;
        public string Title { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
    }
   
}
