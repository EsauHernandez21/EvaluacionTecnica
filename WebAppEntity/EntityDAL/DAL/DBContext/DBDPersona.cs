using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityModel.Model;


namespace EntityDAL.DAL.DBContext
{
    public class DBDPersona:DbContext
    {
        //public DBDPersona() : base(new DbContextOptions<DBDPersona>()) { }

        //El parámetro DbContextOptions<DBDProductos> recibe la configuración necesaria para que Entity Framework
        //pueda conectar y trabajar con la base de datos.
        public DbSet<RegistroPersona> Registro { get; set; } // Aquí se usa la entidad, no el DTO

        public DBDPersona(DbContextOptions<DBDPersona> options) : base(options) { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroPersona>(entity =>
            {
                entity.ToTable("RegistroPersona"); // Mapea la entidad a la tabla
                entity.HasKey(e => e.Id); // Define la clave primaria si es necesario
            });
    

        }

    }
}
