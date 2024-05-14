using System.ComponentModel.DataAnnotations;

namespace CPOnboardingAPI.Models
{
    /// <summary>
    /// This is ApplicationTemplate - the template of the new job application
    /// to be rendered to the Job Seeker on the frontend
    /// </summary>
    public class ApplicationTemplate : BaseEntity
    {
        //public string EmployerId { get; set; } = string.Empty; //this is the PartitionId on Cosmos , If we had authentication, this would probably be the UserId
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        //set it instantly to REQUIRED ... figma says field is mandatory, we can't trust the Employer entirely to remember to set it to required
        public ParagraphQuestion FirstName { get; set; } = new ParagraphQuestion(true); //mandatory
        [Required]
        public ParagraphQuestion LastName { get; set; } = new ParagraphQuestion(true);
        [Required]
        public ParagraphQuestion Email { get; set; } = new ParagraphQuestion(true);
        public ParagraphQuestion Phone { get; set; } = new ParagraphQuestion(true);
        [Required]
        public DropdownQuestion Nationality { get; set; } = new DropdownQuestion(true); //this is a dropwdown question of list of countries/nationalities
        [Required]
        public ParagraphQuestion CurrentResidence { get; set; } = new ParagraphQuestion(true);
        [Required]
        public ParagraphQuestion IDNumber { get; set; } = new ParagraphQuestion(true);
        [Required]
        public DateQuestion DateOfBirth { get; set; } = new DateQuestion(true);
        [Required]
        public DropdownQuestion Gender { get; set; } = new DropdownQuestion(true); //we could have used the YesOrNo question which has max of 2 options but gender may have a third option Uncertain

        public List<BaseQuestion> CustomQuestions { get; set; } = new List<BaseQuestion>(); //custom questions are optional



    }
}
