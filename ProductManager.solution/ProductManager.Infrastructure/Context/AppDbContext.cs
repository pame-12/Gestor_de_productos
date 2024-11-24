using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;

namespace ProductManager.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        // Constructor que permite inyectar las opciones de configuración del DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define el DbSet para cada entidad de tu proyecto
        public DbSet<Product> Products { get; set; } // Representa la tabla "Products"

        // Configuración adicional del modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración personalizada para la entidad Product (opcional)
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id); // Define la clave primaria
                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(100); // Configura restricciones
                entity.Property(p => p.Price)
                      .HasColumnType("decimal(10,2)"); // Configura el tipo de datos
            });

            // Si necesitas agregar más configuraciones de entidades, hazlo aquí
        }
    }
}

