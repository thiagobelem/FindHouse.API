using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindHouse.Business.Models;

namespace FindHouse.Business.Interfaces
{
    public interface IImovelRepository : IRepository<Imovel>
    {
        Task<IEnumerable<Imovel>> ObterImoveisPorAnunciante(Guid anuncianteId);

        Task<IEnumerable<Imovel>> ObterImoveisAnunciantes();

        Task<Imovel> ObterImovelAnunciante(Guid id);

        Task<Imovel> ObterImovelEndereco(Guid id);

        Task<Imovel> ObterImovelAnuncianteEndereco(Guid id);
    }
}
