using CPOnboardingAPI.Models;

namespace CPOnboardingAPI.Dtos.Requests
{
    public class BaseQuestionRequest
    {
        public bool IsInternal { get; set; }
        public bool IsVisible { get; set; }
        public string Type { get; set; } = string.Empty; //type of question - paragraph/text, yesOrNo, dropdown, date, number
        public string Name { get; set; } = string.Empty; //each question should have a name e.g question1, 
        public string Title { get; set; } = string.Empty;
        public bool IsRequired { get; set; }

        public List<Option>? Options { get; set; } 
        public DateTime? DateValue { get; set; }
        public double? Value { get; set; }
    }
}
