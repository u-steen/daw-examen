namespace webapi.Models;

public class Client
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public List<int>? IdComenzi { get; set; }
    public List<Comanda> Comenzi { get; set; }
}