namespace CPOnboardingAPI.Models
{
    public class DateQuestion : BaseQuestion
    {
        public DateQuestion(bool isRequired) : base(isRequired)
        {
        }

        public DateQuestion(string type, string name, string title, bool isRequired) : base(type, name, title, isRequired)
        {
        }
        public DateTime DateValue { get; set; } = DateTime.Now;
    }

}
