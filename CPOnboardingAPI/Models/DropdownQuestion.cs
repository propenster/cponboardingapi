namespace CPOnboardingAPI.Models
{
    public class DropdownQuestion : BaseQuestion
    {
        public DropdownQuestion(bool isRequired) : base(isRequired)
        {
        }

        public DropdownQuestion(string type, string name, string title, bool isRequired) : base(type, name, title, isRequired)
        {
        }
        public List<Option> Options { get; set; } = new List<Option>(); //could have multiple options...
    }
}
