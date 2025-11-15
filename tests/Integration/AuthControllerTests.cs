using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using System.Net;

public class AuthControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AuthControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Login_ShouldReturnOk_WhenCredentialsAreValid()
    {
        var registerData = new
        {
            Nome = "Felipe",
            Email = "felipe@teste.com",
            Senha = "senha123",
            AreaInteresse = "Back-end"
        };

        await _client.PostAsJsonAsync("/api/Usuario/register", registerData);

        var loginData = new
        {
            Email = "felipe@teste.com",
            Senha = "senha123"
        };

        var response = await _client.PostAsJsonAsync("/api/Usuario/login", loginData);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);

        json["token"]?.ToString().Should().NotBeNullOrWhiteSpace();
        json["usuario"]?["email"]?.ToString().Should().Be("felipe@teste.com");
    }

    [Fact]
    public async Task Login_ShouldReturnUnauthorized_WhenCredentialsAreInvalid()
    {
        var loginData = new
        {
            Email = "felipe@example.com",
            Senha = "senhaErrada"
        };

        var response = await _client.PostAsJsonAsync("/api/Usuario/login", loginData);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetUserDetails_ShouldReturnUserData_WhenTokenIsValid()
    {
        var registerData = new
        {
            Nome = "Felipe",
            Email = "felipe2@teste.com",
            Senha = "senha123",
            AreaInteresse = "Back-end"
        };

        await _client.PostAsJsonAsync("/api/Usuario/register", registerData);

        var loginData = new
        {
            Email = "felipe2@teste.com",
            Senha = "senha123"
        };

        var loginResponse = await _client.PostAsJsonAsync("/api/Usuario/login", loginData);
        var loginContent = await loginResponse.Content.ReadAsStringAsync();
        var loginJson = JObject.Parse(loginContent);
        var token = loginJson["token"]?.ToString();

        var idUsuario = loginJson["usuario"]?["idUsuario"]?.ToObject<int>() ?? 1;

        var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Usuario/{idUsuario}");
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var response = await _client.SendAsync(request);

        response.IsSuccessStatusCode.Should().BeTrue();
        var userContent = await response.Content.ReadAsStringAsync();
        userContent.Should().Contain("Felipe");
    }
}
