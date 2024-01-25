namespace webapi.Repositories.Comanda;

public interface IComandaRepository
{
    Task<List<Models.Comanda>> GetAllAsync();
    Task<Models.Comanda?> GetByIdAsync(int id);
    Task<Models.Comanda> CreateAsync(Models.Comanda produs);
    Task<Models.Comanda?> DeleteAsync(int id);
}