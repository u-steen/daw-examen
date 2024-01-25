using Microsoft.EntityFrameworkCore;
using webapi.Data;

namespace webapi.Repositories.Comanda;

public class ComandaRepository : IComandaRepository
{
    private readonly ApplicationDBContext _context;
    public ComandaRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<List<Models.Comanda>> GetAllAsync()
    {
        return await _context.Comenzi.ToListAsync();
    }

    public async Task<Models.Comanda?> GetByIdAsync(int id)
    {
        return await _context.Comenzi.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Models.Comanda> CreateAsync(Models.Comanda comanda)
    {
        await _context.Comenzi.AddAsync(comanda);
        await _context.SaveChangesAsync();
        return comanda;
    }

    public async Task<Models.Comanda?> DeleteAsync(int id)
    {
        Models.Comanda? review = await _context.Comenzi.FirstOrDefaultAsync(r => r.Id == id);
        if (review == null)
        {
            return null;
        }

        _context.Comenzi.Remove(review);
        await _context.SaveChangesAsync();
        return review;
    }
}