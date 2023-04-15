using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_Forum.Data;
using Web_Forum.Models;

namespace Web_Forum.Views.Home.TopicPage
{
    public class IndexModel: PageModel
    {
        private readonly IdentityApplicationDbContext db;
        private readonly ILogger<IndexModel> logger;
        public string? loggedUser;

        public IndexModel(ILogger<IndexModel> logger, IdentityApplicationDbContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        public string? LoggedUser()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                return HttpContext.Session.GetString("UserName");
            }
            else
            {
                return null;
            }
        }

        public IList<Topic>? Topics { get; set; }

        public async Task OnGetAsync()
        {
            Topics = await db.Topic.ToListAsync();
        }
    }
}
