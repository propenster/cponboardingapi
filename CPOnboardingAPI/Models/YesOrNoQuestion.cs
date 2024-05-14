using System.ComponentModel.DataAnnotations;

namespace CPOnboardingAPI.Models
{
    /// <summary>
    /// This is the question kind used for questions with no more than 2 options e.g Yes or No, True Or False
    /// </summary>
    public class YesOrNoQuestion : BaseQuestion
    {
        public YesOrNoQuestion(bool isRequired) : base(isRequired)
        {
        }

        public YesOrNoQuestion(string type, string name, string title, bool isRequired) : base(type, name, title, isRequired)
        {
        }
        [MaxLength(2)]
        public List<Option> Options { get; set; } = new List<Option>(2); //YES or NO...
    }
}
