using webapi.Models;

namespace webapi.Dto.Comanda;

public class ComandaDto
{
    public List<int> IdProduse { get; set; }

    public int IdClient { get; set; }
}