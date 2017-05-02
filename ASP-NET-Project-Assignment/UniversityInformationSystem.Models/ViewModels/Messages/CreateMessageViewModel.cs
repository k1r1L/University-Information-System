namespace UniversityInformationSystem.Models.ViewModels.Messages
{
    using System.ComponentModel.DataAnnotations;
    using Utillities.Constants;

    public class CreateMessageViewModel
    {
        [Required]
        [Display(Name = "Send To:")]
        public string ReceiverUsername { get; set; }


        [Required]
        [StringLength(ValidationConstants.MessageTextLength)]
        [Display(Name = "Message text:")]
        public string Text { get; set; }

        public string SuccessfullSend { get; set; }
    }
}
