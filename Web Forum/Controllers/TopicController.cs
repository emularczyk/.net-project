using Microsoft.AspNetCore.Mvc;
using Web_Forum.Data;
using Web_Forum.Models;

namespace Web_Forum.Controllers
{
    public class TopicController : Controller
    {
        private readonly IdentityApplicationDbContext db;

        public TopicController(IdentityApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Topic> objTopicList = db.Topic;
            return View(objTopicList);
        }
    }
}
