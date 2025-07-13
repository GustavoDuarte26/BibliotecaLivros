using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DBContext
{
    public class BancoDBContext : DbContext
    {
        public BancoDBContext(DbContextOptions<BancoDBContext> options) : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }
    }
}
