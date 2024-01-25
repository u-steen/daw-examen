using Microsoft.EntityFrameworkCore;
using webapi.Data;

namespace webapi.Repositories.Client;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDBContext _context;
    public ClientRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<Models.Client>> GetAllAsync()
    {
        return await _context.Clienti.ToListAsync();
    }

    public async Task<Models.Client?> GetByIdAsync(int id)
    {
        return await _context.Clienti.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Models.Client> CreateAsync(Models.Client client)
    {
        await _context.Clienti.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Models.Client?> DeleteAsync(int id)
    {
        Models.Client? review = await _context.Clienti.FirstOrDefaultAsync(r => r.Id == id);
        if (review == null)
        {
            return null;
        }

        _context.Clienti.Remove(review);
        await _context.SaveChangesAsync();
        return review;
    }
}