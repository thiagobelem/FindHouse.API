using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindHouse.Business.Interfaces;
using FindHouse.Business.Models;
using Microsoft.EntityFrameworkCore;
using FindHouse.Data.Context;

namespace FindHouse.Data.Repository
{
    public class ImovelRepository : Repository<Imovel>, IImovelRepository
    {
        public ImovelRepository(FindHouseDBContext context) : base(context)
        { }

        public async Task<IEnumerable<Imovel>> ObterImoveisAnunciantes()
        {
            return await Db.Imoveis.AsNoTracking()
                                   .Include(i => i.Anunciante)
                                   .ToListAsync();
        }

        public async Task<IEnumerable<Imovel>> ObterImoveisPorAnunciante(Guid anuncianteId)
        {
            return await Buscar(i => i.AnuncianteId == anuncianteId);
        }

        public async Task<Imovel> ObterImovelAnunciante(Guid id)
        {
            return await Db.Imoveis.AsNoTracking()
                                   .Include(i => i.Anunciante)
                                   .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Imovel> ObterImovelEndereco(Guid id)
        {
            return await Db.Imoveis.AsNoTracking()
                                   .Include(i => i.Endereco)
                                   .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Imovel> ObterImovelAnuncianteEndereco(Guid id)
        {
            return await Db.Imoveis.AsNoTracking()
                                   .Include(i => i.Anunciante)
                                   .Include(i => i.Endereco)
                                   .FirstOrDefaultAsync(i => i.Id == id); 
        }
    }
}
