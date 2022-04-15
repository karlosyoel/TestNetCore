using Microsoft.EntityFrameworkCore;

namespace TestNetCore.Models
{
    public class cUserContext:DbContext
    {
        public cUserContext(DbContextOptions<cUserContext> op):base(op)
        {

        }

        public DbSet<cUser> tUser { set; get; }
    }
}
