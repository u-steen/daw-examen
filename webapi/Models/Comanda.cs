namespace webapi.Models;

public class Comanda
{
    public int Id { get; set; }
    public List<int> IdProduse { get; set; }

    public int IdClient { get; set; }
    public Client ClientObj { get; set; }
}