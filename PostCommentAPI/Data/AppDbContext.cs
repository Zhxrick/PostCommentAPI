using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace PostCommentAPI.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options) {}
       
    }
}


