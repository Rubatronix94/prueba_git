using Microsoft.EntityFrameworkCore;
using Appcrud.Models;

namespace Appcrud.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opciones) :base (opciones)
        {
            
        }

        public DbSet<Empleado> Empleados { get; set; }  //Crea una tabla "Empleados"

        //OnModelCreating define las caracteristicas de la tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>(tb =>{
                tb.HasKey(col => col.IdEmpleado);   //IdEmpleado es la primary key

                tb.Property(col => col.IdEmpleado)
                .UseIdentityColumn()    //indica que sea auto-incremental
                .ValueGeneratedOnAdd(); //genera valor solo cuando se agregue una col

                tb.Property(col => col.NombreCompleto).HasMaxLength(50);
                tb.Property(col => col.Correo).HasMaxLength(50);
                
            });

            modelBuilder.Entity<Empleado>().ToTable("Empleados");   //Lo agrega a una table de nombre "Empleados"
        }
    }
}
