using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JokeApp.Models
{
    public class JokeAppDbXontext : DbContext
    {
        public JokeAppDbXontext(DbContextOptions<JokeAppDbXontext> options) : base(options)
        { }

        public DbSet<Joke> Joke { get; set; }
        public DbSet<Vote> Vote { get; set; }

    }
}
