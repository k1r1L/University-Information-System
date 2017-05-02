namespace UniversityInformationSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Users;
    using Utillities.Constants;

    public class Message
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.MessageTextLength)]
        public string Text { get; set; }

        [InverseProperty("SendMessages")]
        [ForeignKey("SenderId")]
        public virtual ApplicationUser Sender { get; set; }

        public string SenderId { get; set; }

        [InverseProperty("InboxMessages")]
        [ForeignKey("ReceiverId")]
        public virtual ApplicationUser Receiver { get; set; }

        public string ReceiverId { get; set; }
    }
}
