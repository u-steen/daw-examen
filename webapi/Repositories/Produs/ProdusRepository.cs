using Microsoft.EntityFrameworkCore;
using webapi.Data;

namespace webapi.Repositories.Produs;

public class ProdusRepository : IProdusRepository
{
    private readonly ApplicationDBContext _context;
    public ProdusRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<List<Models.Produs>> GetAllAsync()
    {
        return await _context.Produse.ToListAsync();
    }

    public async Task<Models.Produs?> GetByIdAsync(int id)
    {
        return await _context.Produse.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Models.Produs> CreateAsync(Models.Produs produs)
    {
        await _context.Produse.AddAsync(produs);
        await _context.SaveChangesAsync();
        return produs;
    }

    public async Task<Models.Produs?> DeleteAsync(int id)
    {
        Models.Produs? review = await _context.Produse.FirstOrDefaultAsync(r => r.Id == id);
        if (review == null)
        {
            return null;
        }

        _context.Produse.Remove(review);
        await _context.SaveChangesAsync();
        return review;
    }
}