using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Domain
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        /// <summary>
        /// Metodo para inicializar datos en base de datos
        /// </summary>
        public void Seed()
        {
            modelBuilder.Entity<MarcaAuto>().HasData(
                DatosIniciales()
            );
        }

        public List<MarcaAuto> DatosIniciales()
        {
            var marcas = new List<MarcaAuto>
    {
        new MarcaAuto() { MarcaAutoId = 1, Codigo = "MAU01", Nombre = "Ford", Descripcion = "Marca americana", CreatedBy = 1 },
        new MarcaAuto() { MarcaAutoId = 2, Codigo = "MAU02", Nombre = "Chevrolet", Descripcion = "Marca americana", CreatedBy = 1 },
        new MarcaAuto() { MarcaAutoId = 3, Codigo = "MAU03", Nombre = "Jeep", Descripcion = "Marca americana", CreatedBy = 1 },
        new MarcaAuto() { MarcaAutoId = 4, Codigo = "MAU04", Nombre = "BMW", Descripcion = "Marca europea", CreatedBy = 1 },
        new MarcaAuto() { MarcaAutoId = 5, Codigo = "MAU05", Nombre = "Mercedes-Benz", Descripcion = "Marca europea", CreatedBy = 1 },
        new MarcaAuto() { MarcaAutoId = 6, Codigo = "MAU06", Nombre = "Volkswagen", Descripcion = "Marca europea", CreatedBy = 1 },
        new MarcaAuto() { MarcaAutoId = 7, Codigo = "MAU07", Nombre = "Toyota", Descripcion = "Marca asiática", CreatedBy = 1 },
        new MarcaAuto() { MarcaAutoId = 8, Codigo = "MAU08", Nombre = "Honda", Descripcion = "Marca asiática", CreatedBy = 1 },
        new MarcaAuto() { MarcaAutoId = 9, Codigo = "MAU09", Nombre = "Mitsubishi", Descripcion = "Marca asiática", CreatedBy = 1 }
    };

            return marcas;
        }

    }
}
