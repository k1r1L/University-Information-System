namespace UniversityInformationSystem.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
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
    }
}