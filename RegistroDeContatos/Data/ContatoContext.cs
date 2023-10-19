using Microsoft.EntityFrameworkCore;
using RegistroDeContatos.Models;

namespace RegistroDeContatos.Data
{
    public class ContatoContext : DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> opts) : base(opts) { }

        public DbSet<Contato> Contatos {get; set;}
    }
}
