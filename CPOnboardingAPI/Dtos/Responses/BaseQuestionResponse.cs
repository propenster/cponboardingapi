using CPOnboardingAPI.Dtos.Requests;
using Newtonsoft.Json;

namespace CPOnboardingAPI.Dtos.Responses
{
    public class BaseQuestionResponse : BaseQuestionRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;
    }
}
