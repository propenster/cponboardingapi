namespace CPOnboardingAPI.Models
{
    public abstract class BaseQuestion : BaseEntity //so our questions could have pk Id... IsVisible and IsInternal that are company-question-wide attributes
    {
        protected BaseQuestion(string type, string name, string title, bool isRequired)
        {
            Type = type;
            Name = name;
            Title = title;
            IsRequired = isRequired;
        }
        protected BaseQuestion(bool isRequired)
        {
            IsRequired = isRequired;
        }

        public string Type { get; set; } //type of question - paragraph/text, yesOrNo, dropdown, date, number
        public string Name { get; set; } //each question should have a name e.g question1, 
        public string Title { get; set; }
        public bool IsRequired { get; set; }
    }
}
