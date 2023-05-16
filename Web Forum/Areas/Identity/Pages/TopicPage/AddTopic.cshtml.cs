using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Web_Forum.Data;
using Web_Forum.Models;

namespace Web_Forum.Views.Home.TopicPage
{
    public class AddTopic: PageModel
    {
        private readonly IdentityApplicationDbContext db;
        private readonly ILogger<IndexModel> logger;
        public string? loggedUser;

        public AddTopic(ILogger<IndexModel> logger, IdentityApplicationDbContext db)
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

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Title")]
            public string Title { get; set; }

            [DataType(DataType.Text)]
            [StringLength(2000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 0)]
            [Display(Name = "Content")]
            public string Content { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToPage("../Account/Login");
            }

            if (id != null)
            {
                Topic editedTopic = await db.FindAsync<Topic>(id);
                Input = new InputModel
                {
                    Title = editedTopic.title,
                    Content = editedTopic.content
                };
                TempData["EditedTopicId"] = editedTopic.id;
            }
            else
            {
                TempData["EditedTopicId"] = -1;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToPage("../Account/Login");
            }

            if (Input != null)
            {
                User user = await db.User.SingleOrDefaultAsync(user => user.UserName == HttpContext.Session.GetString("UserName"));
                int editedTopicId =  int.Parse(TempData["EditedTopicId"].ToString());
                if (editedTopicId != -1)
                {
                    Topic editedTopic = await db.FindAsync<Topic>(editedTopicId); 
                    editedTopic.title = Input.Title;
                    editedTopic.content = Input.Content;
                    editedTopic.user_id = user.Id;
                    db.SaveChanges();
                    return RedirectToPage("./OwnTopicList");
                }
                else if (user != null)
                {
                    Topic topic = new Topic()
                    {
                        title = Input.Title,
                        content = Input.Content,
                        user_id = user.Id
                    };
                    db.Topic.Add(topic);
                    db.SaveChanges();
                }
            }
            return RedirectToPage("./OwnTopicList");
        }
    }
}
