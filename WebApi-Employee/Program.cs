using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi_Employee.Application.Mapping;
using WebApi_Employee.Domain.Model.EmployeeAggregate;
using WebApi_Employee.Infrastucture.Repositories;
using WebApi_Employee.SwaggerConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<DomainToDTOMapping>());

// Configuracao do Swagger para aceitar o token JWT
builder.Services.AddSwaggerGen(s =>
{
    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>()
        }
    });

    s.OperationFilter<SwaggerDefaultValues>(); // Adiciona os valores padrao do Swagger

});

builder.Services.AddApplicationInsightsTelemetry(); 

//Injecao de Dependencia => Usa a interface ao inves de instaciar a classe diretamente
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

//Configuracao da chave secreta do JWT
var key = System.Text.Encoding.ASCII.GetBytes(WebApi_Employee.Key.Secret);

//Configuracao do JWT=> Forca a API a fazer a autenticacao via token JWT
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddApiVersioning()
    .AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV"; // Formato do nome do grupo de versao
        options.SubstituteApiVersionInUrl = true; // Substitui a versao na URL
    });

builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();

// Configuracao do CORS => Permite que qualquer origem acesse a API, para fins de teste
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", police =>
    {
         police.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    { 
        var version = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in version.ApiVersionDescriptions)
        {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",$"ApiEmployess -{description.GroupName.ToUpper()}");
        }
    });
} 
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();