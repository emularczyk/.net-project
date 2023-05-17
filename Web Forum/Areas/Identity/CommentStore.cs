using Microsoft.AspNetCore.Identity;
using Web_Forum.Data;
using Web_Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Web_Forum.Areas.Identity
{
    public class CommentStore
    {
        private readonly IdentityApplicationDbContext db;


        public CommentStore(IdentityApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
