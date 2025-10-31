using CaseProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseProject.Dal.Context;

public class CaseProjectContext : DbContext
{
    public CaseProjectContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}