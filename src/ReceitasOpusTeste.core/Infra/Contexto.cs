using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReceitasOpusTeste.core.Dominio.Entidades;
using ReceitasOpusTeste.core.Infra.Maps;
using System.IO;

namespace ReceitasOpusTeste.core.Infra
{
    //primeira vez
    //Add-Migration InitialCreate -> Update-Database
    //atualizar
    //Add-Migration AddProductReviews -> Update-Database
    //remover
    //Remove-Migration
    //reverter
    //Update-Database LastGoodMigration
    public class Contexto : DbContext
    {
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<IngredienteReceita> IngredienteReceitas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<EntidadeBase>();
            ////geral
            modelBuilder.ApplyConfiguration(new IngredienteMap());
            modelBuilder.ApplyConfiguration(new ReceitaMap());
            modelBuilder.ApplyConfiguration(new IngredienteReceitaMap());

            var listaIngredientes = new []
            {
                new Ingrediente(1,"Leite"),
                new Ingrediente(2,"Sal"),
                new Ingrediente(3,"Pimenta"),
                new Ingrediente(4,"Óleo"),
                new Ingrediente(5,"Azeite"),
                new Ingrediente(6,"Farinha de trigo"),
                new Ingrediente(7,"Ovo"),
                new Ingrediente(8,"Manteiga"),
                new Ingrediente(9,"Queijo"),
                new Ingrediente(10,"Noz-moscada"),
                new Ingrediente(11,"Baunilha"),
                new Ingrediente(12,"Leite de coco")
            };
            modelBuilder.Entity<Ingrediente>().HasData(listaIngredientes);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration appSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            // define the database to use
            optionsBuilder.UseSqlServer(appSetting["ConnectionStrings:SqlServer"]);
        }
    }
}
