using System.Data;
using System.Data.Common;
using System.Diagnostics;
using Npgsql;
using RH360.Data.Interfaces;
using RH360.Data.Mappings;
using RH360.Data.Repositories;

//using RH360.Test;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Adicione as origens permitidas aqui
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => { 
    options.SuppressModelStateInvalidFilter = true; 
});
builder.Services.AddScoped<IDbConnection>(provider =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("Postgree")));
builder.Services.AddScoped<IDapperConnection, DapperConnection>();
builder.Services.AddScoped<IUsuario, Usuario>();
//builder.Services.AddScoped<IDbConnectionWrapper, DbConnectionWrapper>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAngularOrigins");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
