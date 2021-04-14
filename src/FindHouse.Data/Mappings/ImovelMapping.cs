using FindHouse.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHouse.Data.Mappings
{
    public class ImovelMapping : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Titulo)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(a => a.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(1000)");

            builder.Property(a => a.Imagem)
                   .IsRequired()
                   .HasColumnType("varchar(100)");


            // 1 : 1 => Imovel : Endereco
            builder.HasOne(a => a.Endereco)
                   .WithOne(b => b.Imovel);


            builder.ToTable("Imoveis");
        }
    }
}
