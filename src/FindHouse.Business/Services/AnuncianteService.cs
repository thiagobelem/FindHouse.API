using System;
using System.Threading.Tasks;
using System.Linq;
using FindHouse.Business.Interfaces;
using FindHouse.Business.Models;
using FindHouse.Business.Validations;

namespace FindHouse.Business.Services
{
    public class AnuncianteService : BaseService, IAnuncianteService
    {
        private readonly IAnuncianteRepository _anuncianteRepository;

        public AnuncianteService(IAnuncianteRepository anuncianteRepository, INotifier notifier) : base(notifier)
        {
            _anuncianteRepository = anuncianteRepository;
        }

        public async Task Adicionar(Anunciante anunciante)
        {
            if (!ExecutarValidacao(new AnuncianteValidation(), anunciante)) return;

            await _anuncianteRepository.Adicionar(anunciante);
        }

        public async Task Atualizar(Anunciante anunciante)
        {
            if (!ExecutarValidacao(new AnuncianteValidation(), anunciante)) return;

            await _anuncianteRepository.Atualizar(anunciante);
        }

        public async Task Remover(Guid id)
        {
            if (_anuncianteRepository.ObterAnuncianteImoveis(id).Result.Imoveis.Any())
            {
                Notificar("O Anunciante possui imóveis cadastrados");
                return;
            }

            await _anuncianteRepository.Remover(id);
        }

        public void Dispose()
        {
            _anuncianteRepository?.Dispose();
        }
    }
}
