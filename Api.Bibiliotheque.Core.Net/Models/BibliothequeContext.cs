using Microsoft.EntityFrameworkCore;

namespace Api.Bibiliotheque.Core.Net.Models
{
    public class BibliothequeContext : DbContext
    {

        public BibliothequeContext(DbContextOptions<BibliothequeContext> options) : base(options)
        {
        }

        public DbSet<BookModel> Book { get; set; } = null!;

        public DbSet<UserModel> User { get; set; } = null!;

    }
}
