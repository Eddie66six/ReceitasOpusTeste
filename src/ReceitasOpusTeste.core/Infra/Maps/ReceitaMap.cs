using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceitasOpusTeste.core.Dominio.Entidades;

namespace ReceitasOpusTeste.core.Infra.Maps
{
    public class ReceitaMap : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.HasKey(p => p.IdReceita);
            builder.Property(p => p.Nome).HasMaxLength(50);
            builder.Property(p => p.ModoDePreparo).HasMaxLength(1000);
        }
    }
}