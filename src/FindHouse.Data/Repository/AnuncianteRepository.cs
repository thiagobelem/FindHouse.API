using System;
using System.Threading.Tasks;
using FindHouse.Business.Interfaces;
using FindHouse.Business.Models;
using Microsoft.EntityFrameworkCore;
using FindHouse.Data.Context;
using System.Collections.Generic;

namespace FindHouse.Data.Repository
{
    public class AnuncianteRepository : Repository<Anunciante>, IAnuncianteRepository
    {
        public AnuncianteRepository(FindHouseDBContext context) : base(context)
        {}

        public async Task<Anunciante> ObterAnuncianteImoveis(Guid id)
        {
            return await Db.Anunciantes.AsNoTracking()
                                       .Include(a => a.Imoveis)
                                       .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Anunciante>> ObterAnunciantesImoveis()
        {
            return await Db.Anunciantes.AsNoTracking()
                                       .Include(a => a.Imoveis)
                                       .ToListAsync();
        }
    }
}
