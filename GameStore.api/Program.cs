using GameStore.api.Dtos;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
		new DateOnly(1991, 11, 21),


	)





	)
]
app.MapGet("/", () => "Hello From C# API");

app.Run();
