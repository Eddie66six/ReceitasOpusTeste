using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceitasOpusTeste.core.Dominio.Entidades;

namespace ReceitasOpusTeste.core.Infra.Maps
{
    public class IngredienteReceitaMap: IEntityTypeConfiguration<IngredienteReceita>
    {
        public void Configure(EntityTypeBuilder<IngredienteReceita> builder)
        {
            builder.HasKey(p => new { p.IdReceita, p.IdIngrediente });
            builder.HasOne(p => p.Ingrediente).WithMany(p => p.Receitas).HasForeignKey(p => p.IdIngrediente);
            builder.HasOne(p => p.Receita).WithMany(p => p.Ingredientes).HasForeignKey(p => p.IdReceita);
        }
    }
}