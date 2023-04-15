using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Forum.Models;

namespace Web_Forum.Views.Home
{
    public class IndexModel: PageModel
    {
        private readonly ILogger<IndexModel> logger;
        public string? loggedUser;

        public IndexModel(ILogger<IndexModel> logger)
        {
            this.logger = logger;
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

        public void OnGet()
        {

        }
    }
}
