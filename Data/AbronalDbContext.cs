

using abronalPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace abronalPortal.Data
{
    public class AbronalDbContext : IdentityDbContext<Users>
    {
        public AbronalDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}