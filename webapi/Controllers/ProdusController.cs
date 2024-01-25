using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dto.Produs;
using webapi.Models;
using webapi.Repositories.Produs;

namespace webapi.Controllers;

[Route("api/produs")]
[ApiController]
public class ProdusController : ControllerBase
{
    private readonly IProdusRepository _produsRepo;
    private readonly IMapper _mapper;

    public ProdusController(IMapper mapper, IProdusRepository produsRepo)
    {
        _produsRepo = produsRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _produsRepo.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdus([FromRoute] int id)
    {
        var produs = await _produsRepo.GetByIdAsync(id);
        if (produs== null)
            return NotFound();
        return Ok(produs);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProdus([FromBody] CreateProdusDto createdProdus)
    {
        var produs = await _produsRepo.CreateAsync(_mapper.Map<Produs>(createdProdus));
        return CreatedAtAction(nameof(GetProdus), new { produs.Id }, produs);

    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteMovie([FromRoute] int id)
    {
        var movie = await _produsRepo.DeleteAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}