using MediatR;
using Trinca.Churras.Application.Commands;
using Trinca.Churras.Application.Queries;
using Trinca.Churras.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChurrascoContext>();
builder.Services.AddMediatR(typeof(RegistrarParticipanteCommand));
builder.Services.AddMediatR(typeof(IncluirParticipanteChurrascoCommand));
builder.Services.AddMediatR(typeof(AgendarChurrascoCommand));
builder.Services.AddMediatR(typeof(RecuperarDetalhesChurrascoQueries));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
