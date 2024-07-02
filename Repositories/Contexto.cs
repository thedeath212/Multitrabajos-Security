
using Microsoft.EntityFrameworkCore;
using MultitrabajosSecurity.Models;
namespace MultitrabajosSecurity.Repositories
{
    public class Contexto : DbContext
    {
        public Contexto()
        {

        }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        } 

        public DbSet <Rol> Rol { get; set; }
        public DbSet<User> Usuario { get; set; }
    }
}
