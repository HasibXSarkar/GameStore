using GameStore.api.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGameByID";
List<GameDto> games = [
	new(
		1,
		"Street Fighter II",
		"Fighting",
		19.99M,
		new DateOnly(1992, 7, 15)),
	new(
		2,
		"Mortal Kombat",
		"Fighting",
		29.99M,
		new DateOnly(1992, 10, 8)),
	new(
		3,
		"The Legend of Zelda: A Link to the Past",
		"Action-Adventure",
		39.99M,
		new DateOnly(1991, 11, 21)),
];
//GET al games
app.MapGet("/games", () => games);

//GET game by id
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);

//POST /games
app.MapPost("games", (CreateGameDto newGame) =>
{
	GameDto game = new(
		games.Count + 1,
		newGame.Name,
		newGame.Genre,
		newGame.Price,
		newGame.ReleaseDate);
	games.Add(game);

	return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);

});

//PUT /games/{id}
app.MapPut("games/{id}", (int id, UpdateGameDto updateGame) =>
{
	var index = games.FindIndex(game => game.Id == id);
	games[index] = new GameDto(
		id,
		updateGame.Name,
		updateGame.Genre,
		updateGame.Price,
		updateGame.ReleaseDate);
    return Results.NoContent();
});
app.Run();
