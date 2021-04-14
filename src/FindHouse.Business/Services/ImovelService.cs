using System;
using System.Threading.Tasks;
using FindHouse.Business.Interfaces;
using FindHouse.Business.Models;
using FindHouse.Business.Validations;

namespace FindHouse.Business.Services
{
    public class ImovelService : BaseService, IImovelService
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ImovelService(IImovelRepository imovelRepository, IEnderecoRepository enderecoRepository, INotifier notifier):base(notifier)
        {
            _imovelRepository = imovelRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Imovel imovel)
        {
            if (!ExecutarValidacao(new ImovelValidation(), imovel)
                || !ExecutarValidacao(new EnderecoValidation(), imovel.Endereco)) return;

            await _imovelRepository.Adicionar(imovel);
        }

        public async Task Atualizar(Imovel imovel)
        {
            if (!ExecutarValidacao(new ImovelValidation(), imovel)) return;

            await _imovelRepository.Atualizar(imovel);
        }

        public async Task Remover(Guid id)
        {
            var endereco = await _enderecoRepository.ObterEnderecoPorImovel(id);
            if(endereco != null)
            {
               await _enderecoRepository.Remover(endereco.Id);
            }
            await _imovelRepository.Remover(id);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public void Dispose()
        {
            _imovelRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
