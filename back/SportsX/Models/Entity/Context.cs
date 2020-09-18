using Microsoft.EntityFrameworkCore;


namespace ConsulAPI.Models
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
                 : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence("sq_clientes");
        }
    }
}
