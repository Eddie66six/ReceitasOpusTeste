﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReceitasOpusTeste.core.Infra;

namespace ReceitasOpusTeste.core.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20190224222317_AddProductReviews")]
    partial class AddProductReviews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReceitasOpusTeste.core.Dominio.Entidades.Ingrediente", b =>
                {
                    b.Property<int>("IdIngrediente")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("IdIngrediente");

                    b.ToTable("Ingredientes");

                    b.HasData(
                        new { IdIngrediente = 1, Nome = "Leite" },
                        new { IdIngrediente = 2, Nome = "Sal" },
                        new { IdIngrediente = 3, Nome = "Pimenta" },
                        new { IdIngrediente = 4, Nome = "Óleo" },
                        new { IdIngrediente = 5, Nome = "Azeite" },
                        new { IdIngrediente = 6, Nome = "Farinha de trigo" },
                        new { IdIngrediente = 7, Nome = "Ovo" },
                        new { IdIngrediente = 8, Nome = "Manteiga" },
                        new { IdIngrediente = 9, Nome = "Queijo" },
                        new { IdIngrediente = 10, Nome = "Noz-moscada" },
                        new { IdIngrediente = 11, Nome = "Baunilha" },
                        new { IdIngrediente = 12, Nome = "Leite de coco" }
                    );
                });

            modelBuilder.Entity("ReceitasOpusTeste.core.Dominio.Entidades.IngredienteReceita", b =>
                {
                    b.Property<int>("IdReceita");

                    b.Property<int>("IdIngrediente");

                    b.HasKey("IdReceita", "IdIngrediente");

                    b.HasIndex("IdIngrediente");

                    b.ToTable("IngredienteReceitas");
                });

            modelBuilder.Entity("ReceitasOpusTeste.core.Dominio.Entidades.Receita", b =>
                {
                    b.Property<int>("IdReceita")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Calorias");

                    b.Property<string>("ModoDePreparo")
                        .HasMaxLength(1000);

                    b.Property<string>("Nome")
                        .HasMaxLength(100);

                    b.Property<int>("Porcoes");

                    b.HasKey("IdReceita");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("ReceitasOpusTeste.core.Dominio.Entidades.IngredienteReceita", b =>
                {
                    b.HasOne("ReceitasOpusTeste.core.Dominio.Entidades.Ingrediente", "Ingrediente")
                        .WithMany("Receitas")
                        .HasForeignKey("IdIngrediente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReceitasOpusTeste.core.Dominio.Entidades.Receita", "Receita")
                        .WithMany("Ingredientes")
                        .HasForeignKey("IdReceita")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
