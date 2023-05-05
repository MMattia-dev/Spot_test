using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spot_test.Models;

namespace Spot_test.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Spot_test.Models.PlaylistsModel> PlaylistsModel { get; set; } = default!;
        public DbSet<Spot_test.Models.PlaylistsModel2> PlaylistsModel2 { get; set; } = default!;
    }
}