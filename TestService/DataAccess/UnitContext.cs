using TestService.DataAccess.Entity;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace TestService.DataAccess
{
    public class UnitContext: DbContext
    {
        public DbSet<Unit>? Units { get; set; }

    }
}
