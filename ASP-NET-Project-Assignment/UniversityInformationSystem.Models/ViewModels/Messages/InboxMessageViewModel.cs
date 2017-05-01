namespace UniversityInformationSystem.Models.ViewModels.Messages
{
    using System.ComponentModel.DataAnnotations;
    using Utillities;

    public class InboxMessageViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sender:")]
        public string SenderUsername { get; set; }

        [Required]
        [StringLength(ValidationConstants.MessageTextLength)]
        [Display(Name = "Text:")]
        public string Text { get; set; }
    }
}
