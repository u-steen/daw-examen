namespace webapi.Repositories.Client;

public interface IClientRepository
{
    Task<List<Models.Client>> GetAllAsync();
    Task<Models.Client?> GetByIdAsync(int id);
    Task<Models.Client> CreateAsync(Models.Client produs);
    Task<Models.Client?> DeleteAsync(int id);
}