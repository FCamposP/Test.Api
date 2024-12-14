using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using Test.Application.Contracts;
using Test.Domain.Entities.Common;
using Test.Domain;
using Test.Domain.Entities;

namespace Test.Persistence
{
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {


        public DbSet<MarcaAuto> MarcaAutos { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //Cargar automaticamente las configuraciones de todas las entidades
            var types = from t in Domain.AssemblyReference.Assembly.GetExportedTypes()
                        where t.IsClass && t.Namespace!.Contains("Entities") && !t.IsAbstract
                        && !t.IsGenericType && !t.IsNested
                        select t;


            foreach (var t in types.AsParallel())
            {
                modelBuilder.Entity(t);

                //agregar valores por default a campos IsActive=true y Created=(fecha y hora actual)
                if (t.GetProperty("IsActive") != null)
                    modelBuilder.Entity(t).Property("IsActive").HasDefaultValue(true);
                if (t.GetProperty("Created") != null)
                    modelBuilder.Entity(t).Property("Created").HasDefaultValueSql("CURRENT_TIMESTAMP");

                //Implementacion de SoftDelete, para cargar solo archivos activos a nivel de base de datos
                if (typeof(ISoftDelete).IsAssignableFrom(t))
                    modelBuilder.Entity(t).HasQueryFilter(Help.GenerateQueryFilterLambda(t));
            }

               modelBuilder.Ignore<AuditableEntity>();

            base.OnModelCreating(modelBuilder);

            //Cargar datos iniciales en Base de Datos
            new DbInitializer(modelBuilder).Seed();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now; break;
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.Now; break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
