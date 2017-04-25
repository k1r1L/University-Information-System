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
        private IUsersService usersService;

        public MessagesController(IMessagesService messagesService, IUsersService usersService)
        {
            this.messagesService = messagesService;
            this.usersService = usersService;
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
                ApplicationUser receiverAppUser =
                    this.usersService.GetUserByUsername(messageVm.ReceiverUsername);
                string senderUsername = HttpContext.User.Identity.Name;
                ApplicationUser senderAppUser =
                  this.usersService.GetUserByUsername(senderUsername);

                if (receiverAppUser != null && senderAppUser != null)
                {
                    this.messagesService.Create(senderAppUser.Id, receiverAppUser.Id, messageVm.Text);
                }
            }

            return this.View();
        }

        [Route("usernames")]
        public ActionResult GetAllUsernames(string username)
        {
            if (username == null)
            {
                return RedirectToAction("Create");
            }

            string currentUsername = HttpContext.User.Identity.Name;
            string[] allUsernames = this.usersService
                .GetAllUsernames(currentUsername)
                .Where(u => u.ToLower().Contains(username.ToLower()))
                .ToArray();

            return this.Json(allUsernames, JsonRequestBehavior.AllowGet);
        }
    }
}