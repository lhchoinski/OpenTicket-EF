using Microsoft.EntityFrameworkCore;
using OpenTicket.Domain.Entities;

namespace OpenTicket.Data.Context;
public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {

    }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Ticket>? Tickets { get; set; }


}