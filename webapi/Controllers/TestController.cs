using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers;

[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public TestController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _context.TestModels.ToListAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _context.TestModels.FirstOrDefaultAsync(t => t.Id == id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}