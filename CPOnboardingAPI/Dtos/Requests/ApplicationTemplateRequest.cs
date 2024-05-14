using CPOnboardingAPI.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CPOnboardingAPI.Dtos.Requests
{
    public class ApplicationTemplateRequest
    {
        public bool IsInternal { get; set; }
        public bool IsVisible { get; set; }
        public string EmployerId { get; set; } = string.Empty; //this is the PartitionId on Cosmos , If we had authentication, this would probably be the UserId
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        //set it instantly to REQUIRED ... figma says field is mandatory, we can't trust the Employer entirely to remember to set it to required
        public BaseQuestionRequest FirstName { get; set; } = new(); //mandatory
        [Required]
        public BaseQuestionRequest LastName { get; set; } = new();
        [Required]
        public BaseQuestionRequest Email { get; set; } = new();
        public BaseQuestionRequest Phone { get; set; }
        [Required]
        public DropdownQuestionRequest Nationality { get; set; } = new(); //this is a dropwdown question of list of countries/nationalities
        [Required]
        public BaseQuestionRequest CurrentResidence { get; set; } = new();
        [Required]
        public BaseQuestionRequest IDNumber { get; set; } = new();
        [Required]
        public DateQuestionRequest DateOfBirth { get; set; } = new();
        [Required]
        public DropdownQuestionRequest Gender { get; set; } = new (); //we could have used the YesOrNo question which has max of 2 options but gender may have a third option Uncertain
        public List<BaseQuestionRequest> CustomQuestions { get; set; } = new List<BaseQuestionRequest>(); //custom questions are optional
    }
}
