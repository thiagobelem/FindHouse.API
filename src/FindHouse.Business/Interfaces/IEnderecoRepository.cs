using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindHouse.Business.Models;

namespace FindHouse.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorImovel(Guid imovelId);
    }
}
