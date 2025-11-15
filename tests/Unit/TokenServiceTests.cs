using Infrastructure.Security;
using Domain.Entities;
using Xunit;
using FluentAssertions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class TokenServiceTests
{
    private readonly ITokenService _tokenService;
    private readonly string _secretKey = "chaveSuperSecretaTalencyDudaFelipeSamuel1234567890";

    public TokenServiceTests()
    {
        _tokenService = new TokenService(_secretKey);
    }

    [Fact]
    public void GenerateToken_ShouldReturnToken_WhenUserIsValid()
    {
        var usuario = Usuario.Create(
            nome: "Felipe",
            email: "felipe@teste.com",
            senhaHash: "hashQualquerAqui",
            areaInteresse: "Tecnologia"
        );

        usuario.IdUsuario = 1;

        var token = _tokenService.GenerateToken(usuario);

        token.Should().NotBeNullOrEmpty();

        var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
        jwtToken.Should().NotBeNull();

        jwtToken?
            .Claims
            .Should()
            .Contain(c => c.Type == ClaimTypes.NameIdentifier && c.Value == usuario.IdUsuario.ToString());
    }
}
