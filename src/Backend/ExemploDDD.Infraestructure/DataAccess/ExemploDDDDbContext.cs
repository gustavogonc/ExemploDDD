using ExemploDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExemploDDD.Infraestructure.DataAccess;
public class ExemploDDDDbContext : DbContext
{
    public ExemploDDDDbContext(DbContextOptions<ExemploDDDDbContext> options) : base(options){ }

    public DbSet<User> Users { get; set; }
}

