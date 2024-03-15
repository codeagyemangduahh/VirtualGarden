using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VirtualGarden.Data;

public class ApplicationDbContext : IdentityUserContext<Gardener, int>
{
    public DbSet<Garden> Gardens { get; set; } = null!;
    public DbSet<Plant> Plants { get; set; } = null!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
