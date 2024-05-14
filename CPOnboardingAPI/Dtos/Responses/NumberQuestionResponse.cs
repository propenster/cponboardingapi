using CPOnboardingAPI.Dtos.Requests;
using Newtonsoft.Json;

namespace CPOnboardingAPI.Dtos.Responses
{
    public class NumberQuestionResponse : NumberQuestionRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;
    }
}
