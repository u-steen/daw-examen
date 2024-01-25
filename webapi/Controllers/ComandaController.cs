using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Dto.Comanda;
using webapi.Models;
using webapi.Repositories.Comanda;

namespace webapi.Controllers;

[Route("api/comanda")]
[ApiController]
public class ComandaController : ControllerBase
{
    private readonly IComandaRepository _comandaRepo;
    private readonly IMapper _mapper;
    public ComandaController(IComandaRepository comandaRepo, IMapper mapper)
    {
        _comandaRepo = comandaRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _comandaRepo.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdus([FromRoute] int id)
    {
        var produs = await _comandaRepo.GetByIdAsync(id);
        if (produs== null)
            return NotFound();
        return Ok(produs);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComanda([FromBody] CreateComandaDto createdComanda)
    {
        var produs = await _comandaRepo.CreateAsync(_mapper.Map<Comanda>(createdComanda));
        return CreatedAtAction(nameof(GetProdus), new { produs.Id }, produs);

    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteComanda([FromRoute] int id)
    {
        var movie = await _comandaRepo.DeleteAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}