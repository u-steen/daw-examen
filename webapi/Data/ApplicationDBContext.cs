using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }
    // AICI PUNEM TABELELE
    public DbSet<TestModel>TestModels{get;set;}
}