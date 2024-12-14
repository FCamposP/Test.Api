using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Api.Controllers;
using Test.Application.Contracts;
using Test.Domain.Entities;
using Test.Persistence;
using Test.Persistence.Repositories;

namespace Test.Api.Tests;

public class MarcasAutosControllerTests
{
    private IBaseRepository<MarcaAuto> GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        var context = new ApplicationDbContext(options);
        IQueryManager<MarcaAuto> queryManager = new QueryManager<MarcaAuto>(context);
        IBaseRepository<MarcaAuto> baseRepository = new BaseRepository<MarcaAuto>(queryManager);
        // Agregar datos de prueba
        context.MarcaAutos.AddRange(
               new MarcaAuto() { MarcaAutoId = 1, Codigo = "MAU01", Nombre = "Ford", Descripcion = "Marca americana", CreatedBy = 1 },
               new MarcaAuto() { MarcaAutoId = 2, Codigo = "MAU02", Nombre = "Chevrolet", Descripcion = "Marca americana", CreatedBy = 1 },
               new MarcaAuto() { MarcaAutoId = 3, Codigo = "MAU03", Nombre = "Jeep", Descripcion = "Marca americana", CreatedBy = 1 },
               new MarcaAuto() { MarcaAutoId = 4, Codigo = "MAU04", Nombre = "BMW", Descripcion = "Marca europea", CreatedBy = 1 },
               new MarcaAuto() { MarcaAutoId = 5, Codigo = "MAU05", Nombre = "Mercedes-Benz", Descripcion = "Marca europea", CreatedBy = 1 },
               new MarcaAuto() { MarcaAutoId = 6, Codigo = "MAU06", Nombre = "Volkswagen", Descripcion = "Marca europea", CreatedBy = 1 },
               new MarcaAuto() { MarcaAutoId = 7, Codigo = "MAU07", Nombre = "Toyota", Descripcion = "Marca asiática", CreatedBy = 1 },
               new MarcaAuto() { MarcaAutoId = 8, Codigo = "MAU08", Nombre = "Honda", Descripcion = "Marca asiática", CreatedBy = 1 },
               new MarcaAuto() { MarcaAutoId = 9, Codigo = "MAU09", Nombre = "Mitsubishi", Descripcion = "Marca asiática", CreatedBy = 1 }
        );
        context.SaveChanges();

        return baseRepository;
    }

    [Fact]
    public void Get_ReturnsAllMarcas()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new MarcasAutosController(context);

        // Act: Llamar al método del controlador
        IQueryable<MarcaAuto> result = controller.Get();

        // Assert: Verificar el resultado
        var marcas = result.ToList(); // Convertir IQueryable a lista


        // Verificar que las marcas esperadas están en el resultado
        var expectedCodes = new[] { "MAU01", "MAU02", "MAU03", "MAU04", "MAU05", "MAU06", "MAU07", "MAU08", "MAU09" };
        foreach (var code in expectedCodes)
        {
            Assert.Contains(marcas, m => m.Codigo == code);
        }
    }
}