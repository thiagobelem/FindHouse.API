using FindHouse.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FindHouse.Data.Context
{
    public class FindHouseDBContext : DbContext
    {
        public FindHouseDBContext(DbContextOptions<FindHouseDBContext> options) : base(options)
        {

        }

        public DbSet<Anunciante> Anunciantes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Imovel> Imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configurando todos os mappings de uma vez
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FindHouseDBContext).Assembly);

            //desabilitando cascade delete
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) 
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            //seta config default (varchar(100) para tipos string de todas as entidades, caso não estejam mapeados. 
            //Não sobrescreve os mapeamentos 
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //   .SelectMany(e => e.GetProperties()
            //       .Where(p => p.ClrType == typeof(string))))
            //    property.SetColumnType("varchar(100)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
