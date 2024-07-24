using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories;
using SGChallengeApplication.Repositories.Interfaces;
using SGChallengeApplication.Services;
using SGChallengeApplication.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChallengeSgContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SGDB")));
builder.Services.AddScoped<IBancoRepo, BancoRepo>();
builder.Services.AddScoped<IClienteRepo, ClienteRepo>();
builder.Services.AddScoped<ICuentaRepo, CuentaRepo>();
builder.Services.AddScoped<ILocalidadRepo, LocalidadRepo>();
builder.Services.AddScoped<IMonedaRepo, MonedaRepo>();
builder.Services.AddScoped<IPaisRepo, PaisRepo>();
builder.Services.AddScoped<IProvinciaRepo, ProvinciaRepo>();
builder.Services.AddScoped<ISucursalRepo, SucursalRepo>();
builder.Services.AddScoped<IUsuarioRepo, UsuarioRepo>();
builder.Services.AddScoped<ITipoCuentaRepo, TipoCuentaRepo>();

builder.Services.AddScoped<IUtilidadesRepo, UtilidadesRepo>();
builder.Services.AddScoped<ICrearCuentaService, CrearCuentaService>();
builder.Services.AddScoped<ICrearClienteService, CrearClienteService>();
builder.Services.AddScoped<ICrearUsuarioService, CrearUsuarioService>();
builder.Services.AddScoped<IDepositoService, DepositoService>();
builder.Services.AddScoped<IRetiroService, RetiroService>();
builder.Services.AddScoped<ISaldoService, SaldoService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IAutenticarService, AutenticarService>();

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
