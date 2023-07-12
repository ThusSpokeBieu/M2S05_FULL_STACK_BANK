// See https://aka.ms/new-console-template for more information
using CLI.BANK.Services;
using Spectre.Console;

Console.WriteLine("Hello, World!");

var app = new ContaService();

RunApp();

void RunApp()
{
  AnsiConsole.Clear();

  var selection = AnsiConsole.Prompt(
  new SelectionPrompt<string>()
      .Title("Escolha uma opção.")
      .MoreChoicesText("[grey](Mova com as setas e selecione com enter.)[/]")
      .AddChoices(new[] {
          "Exibir clientes", "Criar conta", "Buscar por número de conta", "Sair"
      }));

  switch (selection)
  {
    case "Exibir clientes":
      app.ExibirClientes();
      RunApp();
      break;
    case "Criar conta":
      app.CriarConta();
      RunApp();
      break;
    case "Buscar por número de conta":
      app.BuscarClientePorNumeroDeConta();
      RunApp();
      break;
    default:
      AnsiConsole.MarkupLine("[blue] See ya! [/]");
      break;
  }
}
