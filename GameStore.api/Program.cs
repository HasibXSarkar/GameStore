using GameStore.api.Endpoints;
using GameStore.api.Data;

var builder = WebApplication.CreateBuilder(args);

var connstring = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connstring);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
