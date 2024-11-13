using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EnergyTech_NET.Data;
using EnergyTech_NET.Repository;
using EnergyTech_NET.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Firebase
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("energytechnet-firebase.json")
});

// Adiciona serviços ao container
builder.Services.AddDbContext<DataContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Registra repositórios
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEnergiaRepository, EnergiaRepository>();
builder.Services.AddScoped<IEstoqueEnergiaRepository, EstoqueEnergiaRepository>();
builder.Services.AddScoped<IFornecedoresRepository, FornecedoresRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// Configuração da Autenticação e Autorização com JWT do Firebase
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/energytechnet-fcd51";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/energytechnet-fcd51",
            ValidateAudience = true,
            ValidAudience = "energytechnet-fcd51",
            ValidateLifetime = true
        };
    });

builder.Services.AddControllers();

// Configuração do Swagger para Autorização JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EnergyTech - A TPC Solution",
        Description = "API desenvolvida pelo grupo Think, Plan & Code para manuseio de dados do aplicativo EnergyTech",
        Contact = new OpenApiContact
        {
            Name = "Think, Plan & Code",
            Email = "thinkplancode@gmail.com.br"
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira o token JWT Firebase com Bearer [token]",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
