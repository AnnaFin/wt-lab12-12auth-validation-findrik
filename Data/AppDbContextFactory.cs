using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace wt_lab12_12auth_validation_findrik.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        // Используем строку подключения к вашей локальной базе данных
        // Если вы изменили пароль или имя БД, обновите эту строку
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=wt_lab8;Username=postgres;Password=твой_пароль");

        return new AppDbContext(optionsBuilder.Options);
    }
}