using System;
using System.Threading.Tasks;
using FindHouse.Business.Models;

namespace FindHouse.Business.Interfaces
{
    public interface IAnuncianteService : IDisposable
    {
        Task Adicionar(Anunciante anunciante);

        Task Atualizar(Anunciante anunciante);

        Task Remover(Guid id);
    }
}
