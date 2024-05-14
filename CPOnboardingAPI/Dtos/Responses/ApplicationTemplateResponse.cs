using CPOnboardingAPI.Dtos.Requests;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CPOnboardingAPI.Dtos.Responses
{
    public class ApplicationTemplateResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;
        public bool IsInternal { get; set; }
        public bool IsVisible { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        //set it instantly to REQUIRED ... figma says field is mandatory, we can't trust the Employer entirely to remember to set it to required
        public BaseQuestionResponse FirstName { get; set; } = new(); //mandatory
        [Required]
        public BaseQuestionResponse LastName { get; set; } = new();
        [Required]
        public BaseQuestionResponse Email { get; set; } = new();
        public BaseQuestionResponse Phone { get; set; } = new();
        [Required]
        public DropdownQuestionResponse Nationality { get; set; } = new(); //this is a dropwdown question of list of countries/nationalities
        [Required]
        public BaseQuestionResponse CurrentResidence { get; set; } = new();
        [Required]
        public BaseQuestionResponse IDNumber { get; set; } = new();
        [Required]
        public DateQuestionResponse DateOfBirth { get; set; } = new();
        [Required]
        public DropdownQuestionResponse Gender { get; set; } = new(); //we could have used the YesOrNo question which has max of 2 options but gender may have a third option Uncertain
        public List<BaseQuestionResponse> CustomQuestions { get; set; } = new List<BaseQuestionResponse>(); //custom questions are optional
    }
}
