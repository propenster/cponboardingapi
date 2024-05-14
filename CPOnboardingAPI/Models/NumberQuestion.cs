namespace CPOnboardingAPI.Models
{
    public class NumberQuestion : BaseQuestion
    {
        public NumberQuestion(bool isRequired) : base(isRequired)
        {
        }

        public NumberQuestion(string type, string name, string title, bool isRequired) : base(type, name, title, isRequired)
        {
        }

        public double Value { get; set; }
    }
}
