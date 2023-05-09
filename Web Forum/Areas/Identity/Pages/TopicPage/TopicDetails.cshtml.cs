using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_Forum.Data;
using Web_Forum.Models;

namespace Web_Forum.Views.Home.TopicPage
{
    public class TopicDetails: PageModel
    {
        private readonly IdentityApplicationDbContext db;
        private readonly ILogger<IndexModel> logger;
        public string? loggedUser;

        public TopicDetails(ILogger<IndexModel> logger, IdentityApplicationDbContext db)
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

        public Topic? Topic { get; set; }

        public IList<Comment>? Comments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Topic = await db.FindAsync<Topic>(id);

            if (Topic == null)
            {
                return NotFound();
            }
            Comments = await db.Comment.Where(c => c.topic_id == id).ToListAsync(); 

            return Page();
        }
    }
}
