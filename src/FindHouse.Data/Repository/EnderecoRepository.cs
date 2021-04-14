using System;
using System.Threading.Tasks;
using FindHouse.Business.Interfaces;
using FindHouse.Business.Models;
using FindHouse.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FindHouse.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(FindHouseDBContext context) : base(context)
        { }

        public async Task<Endereco> ObterEnderecoPorImovel(Guid imovelId)
        {
            return await Db.Enderecos.AsNoTracking()
                                     .FirstOrDefaultAsync(i => i.ImovelId == imovelId);
        }
    }
}
