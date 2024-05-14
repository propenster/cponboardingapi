using CPOnboardingAPI.Dtos.Requests;
using Newtonsoft.Json;

namespace CPOnboardingAPI.Dtos.Responses
{
    public class DateQuestionResponse : DateQuestionRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;
    }
}
