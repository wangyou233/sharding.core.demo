using EFCore.Sharding.Demo.Entities;
using Microsoft.EntityFrameworkCore;
using ShardingCore.Core.VirtualRoutes.TableRoutes.RouteTails.Abstractions;
using ShardingCore.Sharding;
using ShardingCore.Sharding.Abstractions;

namespace EFCore.Sharding.Demo.DbContext;

public class AppDbContext : AbstractShardingDbContext,IShardingTableDbContext

{
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Unit> Units { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public IRouteTail RouteTail { get; set; }

}