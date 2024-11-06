using GuessNumberGame.Models.GameLogic;
using GuessNumberGame.Models.GameView;
using GuessNumberGame.Models.SecretNumberGenerators;
using GuessNumberGame.Models.SecretNumberGenerators.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services
    .AddSingleton<ISecretNumberGenerator, RandomSecretNumberGenerator>()
    .AddSingleton<IGameLogic, GameLogic>()
    .AddSingleton<IGameViewModel, GameViewModel>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=GuessNumberGame}/{action=Index}");

app.Run();

