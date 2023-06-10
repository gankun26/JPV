using Microsoft.EntityFrameworkCore;

namespace CrudProjectJpv.Models
{
    public class Context : DbContext
    {
        public Context ( DbContextOptions<Context> options ) : base(options)
        {

        }

        public DbSet<CadastroPessoa> CadastroPessoas { get; set; }
    }
}
