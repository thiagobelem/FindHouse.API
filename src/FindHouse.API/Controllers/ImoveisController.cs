using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindHouse.API.ViewModels;
using FindHouse.Business.Interfaces;
using FindHouse.Business.Models;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using FindHouse.API.Extensions;

namespace FindHouse.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ImoveisController : MainController
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IImovelService _imovelService;
        private readonly IMapper _mapper;

        public ImoveisController(IImovelRepository imovelRepository, 
                                 IImovelService imovelService, 
                                 IMapper mapper,
                                 INotifier notifier):base(notifier)
        {
            _imovelRepository = imovelRepository;
            _imovelService = imovelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImovelViewModel>>> ObterTodos()
        {
            var imoveis = _mapper.Map<IEnumerable<ImovelViewModel>>(await _imovelRepository.ObterImoveisAnunciantes());
            return Ok(imoveis);
        }

        [ClaimsAuthorize("Imovel", "Ler")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ImovelViewModel>> ObterPorId(Guid id)
        {
            var imovel = _mapper.Map<ImovelViewModel>(await _imovelRepository.ObterImovelAnuncianteEndereco(id));
            if (imovel == null) { return NotFound(); }
            return Ok(imovel);
        }

        [ClaimsAuthorize("Imovel", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ImovelViewModel>> Adicionar(ImovelViewModel imovelViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + imovelViewModel.Imagem;
            if(!UploadArquivo(imovelViewModel.ImagemUpload, imagemNome))
            {
                return CustomResponse(imovelViewModel);
            }

            imovelViewModel.Imagem = imagemNome;
            await _imovelService.Adicionar(_mapper.Map<Imovel>(imovelViewModel));

            //return CreatedAtAction(nameof(ObterPorId), new { id = anunciante.Id }, anunciante);
            return CustomResponse(imovelViewModel);
        }

        [ClaimsAuthorize("Imovel", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ImovelViewModel>> Atualizar(Guid id, ImovelViewModel imovelViewModel)
        {
            if (id != imovelViewModel.Id) return BadRequest();

            var imovelAtualizacao = await _imovelRepository.ObterImovelAnunciante(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if(imovelViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + imovelViewModel.Imagem;
                if(!UploadArquivo(imovelViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }
                imovelAtualizacao.Imagem = imagemNome;
            }

            imovelAtualizacao.AnuncianteId = imovelViewModel.AnuncianteId;
            imovelAtualizacao.AreaTotal = imovelViewModel.AreaTotal;
            imovelAtualizacao.AreaUtil = imovelViewModel.AreaUtil;
            imovelAtualizacao.Banheiros = imovelViewModel.Banheiros;
            imovelAtualizacao.Descricao = imovelViewModel.Descricao;
            imovelAtualizacao.Garagens = imovelViewModel.Garagens;
            imovelAtualizacao.Quartos = imovelViewModel.Quartos;
            imovelAtualizacao.Suites = imovelViewModel.Suites;
            imovelAtualizacao.TipoContrato = (TipoContrato)imovelViewModel.TipoContrato;
            imovelAtualizacao.TipoImovel = (TipoImovel)imovelViewModel.TipoImovel;
            imovelAtualizacao.Titulo = imovelViewModel.Titulo;
            imovelAtualizacao.Valor = imovelViewModel.Valor;
            imovelAtualizacao.ValorCondominio = imovelViewModel.ValorCondominio;

            await _imovelService.Atualizar(imovelAtualizacao);

            //return NoContent();
            return CustomResponse(imovelViewModel);
        }

        [ClaimsAuthorize("Imovel", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var imovel = await _imovelRepository.ObterImovelEndereco(id);

            if (imovel == null) return NotFound();

            await _imovelService.Remover(imovel.Id);

            //return NoContent();
            return CustomResponse();
        }

        [ClaimsAuthorize("Imovel", "Atualizar")]
        [HttpPut("endereco/{id:guid}")]
        public async Task<ActionResult> AtualizarEndereco(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _imovelService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }


        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este Imóvel!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/imoveis", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
