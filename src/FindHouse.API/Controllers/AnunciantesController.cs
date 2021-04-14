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
    public class AnunciantesController : MainController
    {
        private readonly IAnuncianteRepository _anuncianteRepository;
        private readonly IAnuncianteService _anuncianteService;
        private readonly IMapper _mapper;
        public AnunciantesController(IAnuncianteRepository anuncianteRepository, 
                                     IAnuncianteService anuncianteService, 
                                     IMapper mapper,
                                     INotifier notifier):base(notifier)
        {
            _anuncianteRepository = anuncianteRepository;
            _anuncianteService = anuncianteService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AnuncianteViewModel>>> ObterTodos()
        {
            var anunciantes = _mapper.Map<IEnumerable<AnuncianteViewModel>>(await _anuncianteRepository.ObterAnunciantesImoveis());
            return Ok(anunciantes);
        }
        
        [ClaimsAuthorize("Anunciante", "Ler")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AnuncianteViewModel>> ObterPorId(Guid id)
        {
            var anunciante = _mapper.Map<AnuncianteViewModel>(await _anuncianteRepository.ObterPorId(id));
            if(anunciante == null) {return NotFound();}
            return Ok(anunciante);
        }

        [ClaimsAuthorize("Anunciante", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<AnuncianteViewModel>> Adicionar(AnuncianteViewModel anuncianteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + anuncianteViewModel.Imagem;
            if (!UploadArquivo(anuncianteViewModel.ImagemUpload, imagemNome))
            {
                return CustomResponse(anuncianteViewModel);
            }

            anuncianteViewModel.Imagem = imagemNome;
            await _anuncianteService.Adicionar(_mapper.Map<Anunciante>(anuncianteViewModel));

            //return CreatedAtAction(nameof(ObterPorId), new { id = anunciante.Id }, anunciante);
            return CustomResponse(anuncianteViewModel);
        }

        [ClaimsAuthorize("Anunciante", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AnuncianteViewModel>> Atualizar(Guid id, AnuncianteViewModel anuncianteViewModel)
        {
            if (id != anuncianteViewModel.Id) return BadRequest();

            var anuncianteAtualizacao = await _anuncianteRepository.ObterAnuncianteImoveis(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (anuncianteViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + anuncianteViewModel.Imagem;
                if (!UploadArquivo(anuncianteViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }
                anuncianteAtualizacao.Imagem = imagemNome;
            }

            anuncianteAtualizacao.Creci = anuncianteViewModel.Creci;
            anuncianteAtualizacao.Descricao = anuncianteViewModel.Descricao;
            anuncianteAtualizacao.Email = anuncianteViewModel.Email;
            anuncianteAtualizacao.Nome = anuncianteViewModel.Nome;
            anuncianteAtualizacao.Telefone = anuncianteViewModel.Telefone;

            await _anuncianteService.Atualizar(anuncianteAtualizacao);

            //return NoContent();
            return CustomResponse(anuncianteViewModel);
        }

        [ClaimsAuthorize("Anunciante", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var anunciante = await _anuncianteRepository.ObterAnuncianteImoveis(id);

            if (anunciante == null) return NotFound();

            await _anuncianteService.Remover(anunciante.Id);

            //return NoContent();
            return CustomResponse();
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este Anunciante!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/anunciantes", imgNome);

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
