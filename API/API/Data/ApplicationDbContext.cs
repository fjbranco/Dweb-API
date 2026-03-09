using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /// <summary>
    /// Base de dados do nosso projeto
    /// </summary>
    /// <param name="options"></param>
    public class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext(options)
    {

        /* tabelas da base de dados */
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Photography> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MyUser> Users { get; set; }

    }
}
