using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Trilha;
using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Xunit;

namespace Tests.Unit
{
    public class TrilhaServiceTests
    {
        private class FakeTrilhaRepository : ITrilhaRepository
        {
            public List<Trilha> Trilhas { get; } = new();

            public Task<List<Trilha>> GetAllAsync()
            {
                return Task.FromResult(Trilhas.ToList());
            }

            public Task<Trilha?> GetByIdAsync(int id)
            {
                var trilha = Trilhas.FirstOrDefault(t => t.IdTrilha == id);
                return Task.FromResult(trilha);
            }

            public Task CreateAsync(Trilha trilha)
            {
                if (trilha.IdTrilha == 0)
                {
                    var nextId = Trilhas.Count == 0 ? 1 : Trilhas.Max(t => t.IdTrilha) + 1;
                    trilha.IdTrilha = nextId;
                }

                Trilhas.Add(trilha);
                return Task.CompletedTask;
            }

            public Task UpdateAsync(int id, Trilha trilha)
            {
                var existing = Trilhas.FirstOrDefault(t => t.IdTrilha == id);
                if (existing != null)
                {
                    existing.NomeTrilha = trilha.NomeTrilha;
                    existing.Descricao = trilha.Descricao;
                    existing.Area = trilha.Area;
                }

                return Task.CompletedTask;
            }

            public Task DeleteAsync(int id)
            {
                Trilhas.RemoveAll(t => t.IdTrilha == id);
                return Task.CompletedTask;
            }
        }

        private TrilhaService CreateService(out FakeTrilhaRepository fakeRepo)
        {
            fakeRepo = new FakeTrilhaRepository();
            return new TrilhaService(fakeRepo);
        }

        [Fact]
        public async Task GetTrilhaByIdAsync_ShouldReturnTrilhaResponse_WhenTrilhaExists()
        {
            var service = CreateService(out var repo);

            var trilha = Trilha.Create(
                nomeTrilha: "Desenvolvedor Fullstack",
                descricao: "Trilha para dev fullstack",
                area: "Tecnologia"
            );
            trilha.IdTrilha = 1;
            repo.Trilhas.Add(trilha);

            var result = await service.GetTrilhaByIdAsync(1);

            result.Should().NotBeNull();
            result.IdTrilha.Should().Be(1);
            result.NomeTrilha.Should().Be("Desenvolvedor Fullstack");
            result.Area.Should().Be("Tecnologia");
        }

        [Fact]
        public async Task GetTrilhaByIdAsync_ShouldThrowKeyNotFound_WhenTrilhaDoesNotExist()
        {
            var service = CreateService(out _);

            var act = async () => await service.GetTrilhaByIdAsync(999);

            await act.Should()
                .ThrowAsync<KeyNotFoundException>()
                .WithMessage("Trilha não encontrada.");
        }

        [Fact]
        public async Task GetAllTrilhasAsync_ShouldReturnAllTrilhas()
        {
            var service = CreateService(out var repo);

            var t1 = Trilha.Create("Trilha 1", "Desc 1", "Tecnologia");
            t1.IdTrilha = 1;
            var t2 = Trilha.Create("Trilha 2", "Desc 2", "Gestão");
            t2.IdTrilha = 2;

            repo.Trilhas.Add(t1);
            repo.Trilhas.Add(t2);

            var result = await service.GetAllTrilhasAsync();

            result.Should().HaveCount(2);
            result.Select(t => t.IdTrilha).Should().Contain(new[] { 1, 2 });
        }

        [Fact]
        public async Task CreateTrilhaAsync_ShouldCreateAndReturnTrilhaResponse()
        {
            var service = CreateService(out var repo);

            var request = new TrilhaRequest
            {
                NomeTrilha = "Cientista de Dados",
                Descricao = "Trilha focada em data science",
                Area = "Tecnologia"
            };

            var result = await service.CreateTrilhaAsync(request);

            result.Should().NotBeNull();
            result.NomeTrilha.Should().Be("Cientista de Dados");
            result.Area.Should().Be("Tecnologia");

            repo.Trilhas.Should().HaveCount(1);
            repo.Trilhas.First().NomeTrilha.Should().Be("Cientista de Dados");
        }

        [Fact]
        public async Task UpdateTrilhaAsync_ShouldUpdateAndReturnTrilhaResponse_WhenTrilhaExists()
        {
            var service = CreateService(out var repo);

            var trilha = Trilha.Create("Antigo Nome", "Desc antiga", "Antiga Área");
            trilha.IdTrilha = 10;
            repo.Trilhas.Add(trilha);

            var request = new TrilhaRequest
            {
                NomeTrilha = "Novo Nome",
                Descricao = "Nova descrição",
                Area = "Nova Área"
            };

            var result = await service.UpdateTrilhaAsync(10, request);

            result.IdTrilha.Should().Be(10);
            result.NomeTrilha.Should().Be("Novo Nome");
            result.Descricao.Should().Be("Nova descrição");
            result.Area.Should().Be("Nova Área");

            var stored = repo.Trilhas.First(t => t.IdTrilha == 10);
            stored.NomeTrilha.Should().Be("Novo Nome");
            stored.Descricao.Should().Be("Nova descrição");
            stored.Area.Should().Be("Nova Área");
        }

        [Fact]
        public async Task UpdateTrilhaAsync_ShouldThrowKeyNotFound_WhenTrilhaDoesNotExist()
        {
            var service = CreateService(out _);

            var request = new TrilhaRequest
            {
                NomeTrilha = "Qualquer",
                Descricao = "Desc",
                Area = "Area"
            };

            var act = async () => await service.UpdateTrilhaAsync(123, request);

            await act.Should()
                .ThrowAsync<KeyNotFoundException>()
                .WithMessage("Trilha não encontrada.");
        }

        [Fact]
        public async Task DeleteTrilhaAsync_ShouldDeleteTrilha_WhenExists()
        {
            var service = CreateService(out var repo);

            var trilha = Trilha.Create("Trilha para deletar", "Desc", "Area");
            trilha.IdTrilha = 5;
            repo.Trilhas.Add(trilha);

            await service.DeleteTrilhaAsync(5);

            repo.Trilhas.Should().BeEmpty();
        }

        [Fact]
        public async Task DeleteTrilhaAsync_ShouldThrowKeyNotFound_WhenTrilhaDoesNotExist()
        {
            var service = CreateService(out _);

            var act = async () => await service.DeleteTrilhaAsync(999);

            await act.Should()
                .ThrowAsync<KeyNotFoundException>()
                .WithMessage("Trilha não encontrada.");
        }
    }
}
