using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Opiekun.Models;

namespace Opiekun.Data;

public class OpiekunDbContext : IdentityDbContext
{
    public DbSet<Zasob> Zasoby { get; set; }

    public OpiekunDbContext(DbContextOptions<OpiekunDbContext> options) : base(options) { }
}
