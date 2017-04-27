namespace UniversityInformationSystem.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models.EntityModels.Users;
    using Models.ViewModels.Messages;
    using Services.Contracts;

    [RoutePrefix("messages")]
    [Authorize]
    public class MessagesController : Controller
    {
        private IMessagesService messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        [Route("create")]
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMessageViewModel messageVm)
        {
            if (this.ModelState.IsValid)
            {
                string senderUsername = HttpContext.User.Identity.Name;
                this.messagesService.Create(senderUsername, messageVm.ReceiverUsername, messageVm.Text);
                return this.RedirectToAction("SuccessfulCreate", new { receiverUsername = messageVm.ReceiverUsername});
            }

            return this.View();
        }

        [Route("success")]
        [HttpGet]
        public ActionResult SuccessfulCreate(string receiverUsername)
        {
            if (receiverUsername == null)
            {
                return this.RedirectToAction("Create");
            }

            CreateMessageSuccessViewModel vm = new CreateMessageSuccessViewModel() { ReceiverUsername = receiverUsername};
            return this.View(vm);
        }

        [Route("usernames")]
        public ActionResult GetAllUsernames(string username)
        {
            if (username == null)
            {
                return RedirectToAction("Create");
            }

            string currentUsername = HttpContext.User.Identity.Name;
            string[] allUsernames = this.messagesService
                .GetAllUsernames(currentUsername)
                .Where(u => u.ToLower().Contains(username.ToLower()))
                .ToArray();

            return this.Json(allUsernames, JsonRequestBehavior.AllowGet);
        }
    }
}