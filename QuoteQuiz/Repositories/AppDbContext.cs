using QuoteQuiz.Models;
using Microsoft.EntityFrameworkCore;

namespace QuoteQuiz.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Character> Characters { get; set; }
    }
}
