using System;
using System.Threading.Tasks;
using FindHouse.Business.Models;

namespace FindHouse.Business.Interfaces
{
    public interface IImovelService : IDisposable
    {
        Task Adicionar(Imovel imovel);

        Task Atualizar(Imovel imovel);

        Task Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}
