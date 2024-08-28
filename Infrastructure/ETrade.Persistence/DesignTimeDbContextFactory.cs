using ETrade.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ETrade.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETradeAPIDBContext>
{
    public ETradeAPIDBContext CreateDbContext(string[] args)
    {
        // bu sınıf bizi  "dotnet ef --startup-project ..\..\Presentation\ETrade.API\  migrations add init"  şeklinde zahmetli migrations işleminden kurtarır ve daha kısa sözdizimini sağlar(dotnet ef migrations add init" gibi).
        DbContextOptionsBuilder<ETradeAPIDBContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ETradeDB;Username=postgres;Password=password;");
        return new(dbContextOptionsBuilder.Options);
    }
}
