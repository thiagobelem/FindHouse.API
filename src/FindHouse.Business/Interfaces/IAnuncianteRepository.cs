using System;
using System.Threading.Tasks;
using FindHouse.Business.Models;
using System.Collections.Generic;

namespace FindHouse.Business.Interfaces
{
    public interface IAnuncianteRepository : IRepository<Anunciante>
    {
        Task<Anunciante> ObterAnuncianteImoveis(Guid id);
        Task<IEnumerable<Anunciante>> ObterAnunciantesImoveis();
    }
}
