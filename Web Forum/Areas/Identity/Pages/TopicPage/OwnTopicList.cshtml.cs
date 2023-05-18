using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web_Forum.Data;
using Web_Forum.Models;

namespace Web_Forum.Views.Home.TopicPage
{
    public class OwnTopicList : PageModel
    {
        private readonly IdentityApplicationDbContext db;
        private readonly ILogger<IndexModel> logger;
        public string? loggedUser;

        public OwnTopicList(ILogger<IndexModel> logger, IdentityApplicationDbContext db)
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

        public async Task<IActionResult> OnGetAsync()
        {
            User user = await db.User.SingleOrDefaultAsync(user => 
                user.UserName == HttpContext.Session.GetString("UserName"));

            if (user == null)
            {
                return RedirectToPage("../Account/Login");
            }

            Topics = await db.Topic
                .Where(t => t.user_id == user.Id)
                .ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetDelete(string id)
        {
            int topicId = int.Parse(id);
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToPage("../Account/Login");
            }
            await DeleteTopicAsync(topicId);

            return RedirectToPage("./OwnTopicList");
        }

        private async Task DeleteTopicAsync(int id)
        {
            Topic deletedTopic = await db.FindAsync<Topic>(id);
            if (deletedTopic != null)
            {
                db.Topic.Remove(deletedTopic);
                db.SaveChanges();
            }
        }
    }
}
