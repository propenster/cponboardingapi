using CPOnboardingAPI.Models;

namespace CPOnboardingAPI.Dtos.Requests
{
    public class DropdownQuestionRequest : BaseQuestionRequest
    {
        public List<Option> Options { get; set; } = new List<Option>();
    }
}
