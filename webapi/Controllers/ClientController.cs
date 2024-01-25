using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi.Dto.Client;
using webapi.Dto.Comanda;
using webapi.Models;
using webapi.Repositories.Client;
using webapi.Repositories.Comanda;

namespace webapi.Controllers;

[Route("api/client")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepo;
    private readonly IMapper _mapper;
    public ClientController(IClientRepository clientRepo, IMapper mapper)
    {
        _clientRepo = clientRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _clientRepo.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdus([FromRoute] int id)
    {
        var produs = await _clientRepo.GetByIdAsync(id);
        if (produs== null)
            return NotFound();
        return Ok(produs);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComanda([FromBody] CreateClientDto createdClient)
    {
        var produs = await _clientRepo.CreateAsync(_mapper.Map<Client>(createdClient));
        return CreatedAtAction(nameof(GetProdus), new { produs.Id }, produs);

    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteComanda([FromRoute] int id)
    {
        var movie = await _clientRepo.DeleteAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}