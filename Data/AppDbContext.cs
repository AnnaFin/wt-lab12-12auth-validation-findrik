using Microsoft.EntityFrameworkCore;
using wt_lab12_12auth_validation_findrik.Models;

namespace wt_lab12_12auth_validation_findrik.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ItTask> Tasks => Set<ItTask>();
    public DbSet<User> Users => Set<User>();
}