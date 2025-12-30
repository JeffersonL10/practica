using Models.P;
using Models.C;
using Microsoft.EntityFrameworkCore;

namespace Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profesor>()
            .HasMany(p => p.Cursos)
            .WithOne(c => c.Profesor)
            .HasForeignKey(c => c.ProfesorId);
        }

        internal async Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public DbSet<Profesor> profesores { get; set; }
        public DbSet<Curso> cursos { get; set; }

    }
}