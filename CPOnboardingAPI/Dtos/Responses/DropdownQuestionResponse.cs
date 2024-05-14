using CPOnboardingAPI.Dtos.Requests;
using Newtonsoft.Json;

namespace CPOnboardingAPI.Dtos.Responses
{
    public class DropdownQuestionResponse : DropdownQuestionRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;
    }
}
