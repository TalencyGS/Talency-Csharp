using Application.DTOs.Resposta;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RespostaService : IRespostaService
    {
        private readonly IRespostaRepository _respostaRepository;
        private readonly ITesteRepository _testeRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public RespostaService(IRespostaRepository respostaRepository, ITesteRepository testeRepository, IUsuarioRepository usuarioRepository)
        {
            _respostaRepository = respostaRepository;
            _testeRepository = testeRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<RespostaResponse> GetRespostaByIdAsync(int id)
        {
            var resposta = await _respostaRepository.GetByIdAsync(id);
            if (resposta == null)
            {
                throw new KeyNotFoundException("Resposta não encontrada.");
            }

            return new RespostaResponse
            {
                IdResposta = resposta.IdResposta,
                IdTeste = resposta.IdTeste,
                IdUsuario = resposta.IdUsuario,
                ConteudoResposta = resposta.ConteudoResposta,
                Pontuacao = resposta.Pontuacao
            };
        }

        public async Task<List<RespostaResponse>> GetRespostasByUsuarioIdAsync(int usuarioId)
        {
            var respostas = await _respostaRepository.GetByUsuarioIdAsync(usuarioId);

            return respostas.Select(r => new RespostaResponse
            {
                IdResposta = r.IdResposta,
                IdTeste = r.IdTeste,
                IdUsuario = r.IdUsuario,
                ConteudoResposta = r.ConteudoResposta,
                Pontuacao = r.Pontuacao
            }).ToList();
        }

        public async Task<RespostaResponse> CreateRespostaAsync(RespostaRequest request)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.IdUsuario);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            var teste = await _testeRepository.GetByIdAsync(request.IdTeste);
            if (teste == null)
            {
                throw new KeyNotFoundException("Teste não encontrado.");
            }

            var resposta = Resposta.Create(teste, usuario, request.ConteudoResposta, 0);

            await _respostaRepository.CreateAsync(resposta);

            return new RespostaResponse
            {
                IdResposta = resposta.IdResposta,
                IdTeste = resposta.IdTeste,
                IdUsuario = resposta.IdUsuario,
                ConteudoResposta = resposta.ConteudoResposta,
                Pontuacao = resposta.Pontuacao
            };
        }

        public async Task<RespostaResponse> UpdateRespostaAsync(int id, RespostaRequest request)
        {
            var resposta = await _respostaRepository.GetByIdAsync(id);
            if (resposta == null)
            {
                throw new KeyNotFoundException("Resposta não encontrada.");
            }

            var teste = await _testeRepository.GetByIdAsync(request.IdTeste);
            if (teste == null)
            {
                throw new KeyNotFoundException("Teste não encontrado.");
            }

            resposta.ConteudoResposta = request.ConteudoResposta;
            resposta.Pontuacao = resposta.Pontuacao;

            await _respostaRepository.UpdateAsync(id, resposta);

            return new RespostaResponse
            {
                IdResposta = resposta.IdResposta,
                IdTeste = resposta.IdTeste,
                IdUsuario = resposta.IdUsuario,
                ConteudoResposta = resposta.ConteudoResposta,
                Pontuacao = resposta.Pontuacao
            };
        }

        public async Task DeleteRespostaAsync(int id)
        {
            var resposta = await _respostaRepository.GetByIdAsync(id);
            if (resposta == null)
            {
                throw new KeyNotFoundException("Resposta não encontrada.");
            }

            await _respostaRepository.DeleteAsync(id);
        }
    }
}
