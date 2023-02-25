using EFCore.Sharding.Demo.DbContext;
using EFCore.Sharding.Demo.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Sharding.Demo.Controllers;

[Route("[controller]/[action]")]
public class UnitController:ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public UnitController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var unit = await _appDbContext.Set<Unit>().FirstOrDefaultAsync(x => x.Id == "2");
        return Ok(unit);
    }

    [HttpGet]
    public void Init()
    {
        for (int i = 1; i < 1000; i++)
        {
            _appDbContext.Set<Unit>().Add(new Unit()
            {
                Id = i.ToString(),
            });
            
        }
        _appDbContext.SaveChanges();
    }
}