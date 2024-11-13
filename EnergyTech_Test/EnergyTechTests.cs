using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using EnergyTech_NET.Data;
using EnergyTech_NET.DTOs;
using EnergyTech_NET.Models;
using EnergyTech_NET.Repository;
using EnergyTech_NET.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Xunit;

public class EnergyTechTests
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly HttpClient _httpClient;
    private readonly IAuthRepository _authRepository;
    private readonly Mock<IConfiguration> _configurationMock; 
    private readonly Mock<DbSet<TbAppCliente>> _mockClientesDbSet;
    private readonly Mock<DataContext> _mockDbContext;
    private readonly ClienteRepository _clienteRepository;

    public EnergyTechTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://example.com") // Endereço fictício para o teste
        };

        // Configurar o Mock de IConfiguration para fornecer a chave de API do Firebase
        _configurationMock = new Mock<IConfiguration>();
        _configurationMock.Setup(c => c["Firebase:ApiKey"]).Returns("fake_api_key");

        // Passa o mock de IConfiguration e o HttpClient para o AuthRepository
        _authRepository = new AuthRepository(_configurationMock.Object, _httpClient);

        _mockClientesDbSet = new Mock<DbSet<TbAppCliente>>();
        _mockDbContext = new Mock<DataContext>();
        _mockDbContext.Setup(m => m.Clientes).Returns(_mockClientesDbSet.Object);

        _clienteRepository = new ClienteRepository(_mockDbContext.Object);
    }

    [Fact]
    public async Task LoginAsync_ReturnsIdToken_WhenCredentialsAreValid()
    {
        // Arrange
        var loginDto = new LoginDTO
        {
            Email = "testeapi@gmail.com",
            Senha = "testeapi123"
        };

        var expectedAuthResponse = new FirebaseLoginResponse
        {
            IdToken = "fake_id_token"
        };

        var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = JsonContent.Create(expectedAuthResponse)
        };

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(httpResponseMessage);

        // Act
        var result = await _authRepository.LoginUserAsync(loginDto);

        // Assert
        Assert.Equal("fake_id_token", result);
    }
}
