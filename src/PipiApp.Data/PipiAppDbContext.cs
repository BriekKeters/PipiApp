using Microsoft.EntityFrameworkCore;
using PipiApp.Models;

    public class PipiAppDbContext : DbContext
    {
        public DbSet<Toilet> Toilets { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public PipiAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
