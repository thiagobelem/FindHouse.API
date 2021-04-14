using FindHouse.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHouse.Data.Mappings
{
    public class AnuncianteMapping : IEntityTypeConfiguration<Anunciante>
    {
        public void Configure(EntityTypeBuilder<Anunciante> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(a => a.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(1000)");

            builder.Property(a => a.Email)
                  .IsRequired()
                  .HasColumnType("varchar(100)");

            builder.Property(a => a.Telefone)
                  .IsRequired()
                  .HasColumnType("varchar(11)");

            builder.Property(a => a.Creci)
                  .IsRequired()
                  .HasColumnType("varchar(20)");


            builder.Property(a => a.Imagem)
                   .IsRequired()
                   .HasColumnType("varchar(100)");


            // 1 : N => Anunciante : Imoveis
            builder.HasMany(a => a.Imoveis)
                   .WithOne(b => b.Anunciante)
                   .HasForeignKey(b => b.AnuncianteId);

            builder.ToTable("Anunciantes");
        }
    }
}
