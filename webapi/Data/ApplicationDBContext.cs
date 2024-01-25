using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
    public DbSet<Produs>Produse{get;set;}
    public DbSet<Comanda>Comenzi{get;set;}
    public DbSet<Client>Clienti{get;set;}
}