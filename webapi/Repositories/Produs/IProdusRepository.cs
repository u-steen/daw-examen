namespace webapi.Repositories.Produs;

public interface IProdusRepository
{
    Task<List<Models.Produs>> GetAllAsync();
    Task<Models.Produs?> GetByIdAsync(int id);
    Task<Models.Produs> CreateAsync(Models.Produs produs);
    Task<Models.Produs?> DeleteAsync(int id);
}