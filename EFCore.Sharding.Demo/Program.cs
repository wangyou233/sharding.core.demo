using EFCore.Sharding.Demo.DbContext;
using EFCore.Sharding.Demo.TableRoutes;
using Microsoft.EntityFrameworkCore;
using ShardingCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ServiceCollection services = new ServiceCollection();
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
//配置初始化

// builder.Services.AddDbContext<AppDbContext>(options =>
// {
//     options.UseMySql( "server=localhost;user=root;database=Test;port=3306;password=root;SslMode=None",serverVersion).EnableSensitiveDataLogging()
//         .EnableDetailedErrors();
// });
builder.Services.AddShardingDbContext<AppDbContext>().UseRouteConfig(op =>
{
    op.AddShardingTableRoute<UnitVirtualTableRoute>();
    
}).UseConfig((sp, op) =>
{
    op.UseShardingQuery((conn, builder) =>
    {
        builder.UseMySql(conn,serverVersion);
    });
    op.UseShardingTransaction((conn, builder) =>
    {
        builder.UseMySql(conn,serverVersion);
    });
    op.AddDefaultDataSource(Guid.NewGuid().ToString("n"),
        "server=localhost;user=root;database=Test;port=3306;password=root;SslMode=None");
}).AddShardingCore();
var app = builder.Build();
// app.ApplicationServices.UseAutoTryCompensateTable();
// (IApplicationBuilder) app.UseAuto
app.Services.UseAutoTryCompensateTable();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();