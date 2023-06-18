using AutoMapper;
using BZPAY_BE.BussinessLogic.auth.ServiceImplementation;
using BZPAY_BE.BussinessLogic.auth.ServiceInterface;
using BZPAY_BE.Common.Profiles;
using BZPAY_BE.Models;
using BZPAY_BE.Repositories.Implementations;
using BZPAY_BE.Repositories.Interfaces;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("MembershipContext");
builder.Services.AddDbContext<dev_ticketContext>(x => x.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb")));

// Add services
 builder.Services.AddScoped<IAspnetUserService, AspnetUserService>();
// Agregamos los servicios 
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEntradaService, EntradaService>();
builder.Services.AddScoped<IEscenarioService, EscenarioService>();
builder.Services.AddScoped<ITipoEventoService, TipoEventoService>();

// Add repositories
 builder.Services.AddScoped<IAspnetUserRepository, AspnetUserRepository>();
// Agregamos los repositorios
builder.Services.AddScoped<IAsientoRepository, AsientoRepository>();
builder.Services.AddScoped<IEntradaRepository, EntradaRepository>();
builder.Services.AddScoped<IEscenarioRepository, EscenarioRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<ITipoEscenarioRepository, TipoEscenarioRepository>();
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();

// Auto Mapper Configurations
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AspnetuserProfile());
    mc.AddProfile(new AspnetMembershipProfile());
    mc.AddProfile(new EventoProfile());
    mc.AddProfile(new EntradaProfile());
    mc.AddProfile(new DetalleEntradaProfile());
    mc.AddProfile(new DetalleEventoProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


// Add services to the container.
builder.Services.AddControllers();

//Add Localization Service
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();
builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
                    {
                        options.AddPolicy(name: "AllowAllHeaders",
                            builder =>
                            {
                                builder.AllowAnyHeader()
                                       .AllowAnyMethod()
                                       .WithOrigins("https://localhost:3000");
                            });                                                  
                    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllHeaders");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var supportedCultures = new[] { "es", "en" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

localizationOptions.RequestCultureProviders.Clear();
localizationOptions.RequestCultureProviders.Add(new QueryStringRequestCultureProvider() { QueryStringKey = "lang" });

app.UseRequestLocalization(localizationOptions);

app.Run();
