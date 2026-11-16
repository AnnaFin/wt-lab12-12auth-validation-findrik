using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_findrik.Models;

namespace wt_lab8_8razor_postgresql_findrik.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ItTask> Tasks => Set<ItTask>();
}