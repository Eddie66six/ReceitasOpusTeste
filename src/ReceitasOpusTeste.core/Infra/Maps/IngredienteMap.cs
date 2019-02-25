using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceitasOpusTeste.core.Dominio.Entidades;

namespace ReceitasOpusTeste.core.Infra.Maps
{
    public class IngredienteMap : IEntityTypeConfiguration<Ingrediente>
    {
        public void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.HasKey(p => p.IdIngrediente);
        }
    }
}