using Microsoft.EntityFrameworkCore;
using System;
using WebPasajero.Models;

namespace WebPasajero.Data
{
    public class PasajeroContext : DbContext
    {
        public PasajeroContext(DbContextOptions<PasajeroContext> options) : base(options)
        {
        }

        public DbSet<Pasajero> Pasajeros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OPCIONAL PARA INICIALIZAR DATOS EN LA BASE DE DATOS
            //INICIALIZA LA TABLA PERSONA CON DOS INSTANCIAS

            modelBuilder.Entity<Pasajero>().HasData(
               new Pasajero   
               {
                   PasajeroId = 1,
                   Nombre = "Tara",
                   Apellido = "Brewer",
                   FechaNacimiento = new DateTime(2010,12,1),
                   Ciudad = "Alabama"
               },
               new Pasajero
               {
                   PasajeroId = 2,
                   Nombre = "Andrew",
                   Apellido = "Tippett",
                   FechaNacimiento = new DateTime(1985,10,2),
                   Ciudad = "New York",
                  
               });
        }
    }
}
