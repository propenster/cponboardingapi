using System.ComponentModel.DataAnnotations;

namespace CPOnboardingAPI.Models
{
    /// <summary>
    /// This is ApplicationTemplate - the template of the new job application
    /// to be rendered to the Job Seeker on the frontend
    /// </summary>
    public class ApplicationTemplate : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [MaxLength(9)]
        public List<Question> PersonalInfo { get; set; } = new List<Question>(9); //according to the figma, there can only be 9 PersonalInfo questions

    }
}
