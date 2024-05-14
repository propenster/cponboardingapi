namespace CPOnboardingAPI.Models
{
    public class ParagraphQuestion : BaseQuestion
    {
        public ParagraphQuestion(string type, string name, string title, bool isRequired) : base(type, name, title, isRequired)
        {
        }
        public ParagraphQuestion(bool isRequired) : base(isRequired)
        {

        }
    }
}
