
using CLI.BANK.Entities;
using Spectre.Console;
using static CLI.BANK.Validators.NumeroDeContaValidator;

namespace CLI.BANK.Services;
internal class ContaService : IContaService
{
  public static LinkedList<Cliente> Clientes = new ();
  
  public void ExibirClientes()
  {
    var grid = new Grid();

    grid.AddColumn();
    grid.AddColumn();
    grid.AddColumn();
    grid.AddColumn();
    grid.AddColumn();

    grid.AddRow(new Text[]{
      new Text("Numero Conta", new Style(Color.Gold3, Color.Black)).LeftJustified(),
      new Text("Tipo de Conta", new Style(Color.Gold3, Color.Black)).Centered(),
      new Text("Nome", new Style(Color.Gold3, Color.Black)).Centered(),
      new Text("Saldo", new Style(Color.Gold3, Color.Black)).Centered(),
      new Text("Endereço", new Style(Color.Gold3, Color.Black)).RightJustified(),
    });

    foreach (var cliente in Clientes)
    {
      grid.AddRow(new Text[]{
        new Text($"{cliente.NumeroConta}").LeftJustified(),
        new Text($"{cliente.TipoDeConta}").Centered(),
        new Text($"{cliente.Nome}").Centered(),
        new Text($"R${cliente.Saldo.ToString("N2")}").Centered(),
        new Text($"{cliente.Endereco}").RightJustified()
      });
    }
       
    AnsiConsole.Write(grid);
    Console.ReadKey();
  }

  public void CriarConta()
  {
    AnsiConsole.Clear();

    var tipoDeConta = AnsiConsole.Prompt(
      new SelectionPrompt<string>()
          .Title("Qual tipo de [green]conta[/] será criada?") 
          .PageSize(10)
          .MoreChoicesText("[grey](Use as setas e aperte enter para selecionar uma opção[/]")
          .AddChoices(new[] {
              "Pessoa Física", "Pessoa Jurídica", "Voltar"
          }));

    switch (tipoDeConta)
    {
      case "Pessoa Física":
        CriarPessoaFisca();
        break;
      case "Pessoa Jurídica":
        CriarPessoaJuridica();
        break;
      default:
        break;
    }

  }

  public void BuscarClientePorNumeroDeConta()
  {
    var numeroDeConta = AnsiConsole.Prompt(
        new TextPrompt<int>("Insira o número da conta que quer buscar:")
           .PromptStyle("green"));

    var conta = Clientes.FirstOrDefault(cliente => 
        cliente.NumeroConta.Equals(numeroDeConta));

    if (conta is null)
    {
      AnsiConsole.MarkupLine("[red]Número de conta não encontrado, por favor insira um número correto.[/]");
      AnsiConsole.WriteLine();
    } else
    {
      conta.ResumoCliente();
      Console.ReadKey();
    }
  }

  public void CriarPessoaFisca()
  {
    var nome = AnsiConsole.Prompt(
      new TextPrompt<string>("Digite o nome: ")
          .PromptStyle("green"));

    var cpf = AnsiConsole.Prompt(
      new TextPrompt<string>("Digite o CPF: ")
          .PromptStyle("green"));

    var nascimento = AnsiConsole.Prompt(
      new TextPrompt<DateOnly>("Digite a Data de Nascimento: ")
          .PromptStyle("green"));

    var endereco = AnsiConsole.Prompt(
      new TextPrompt<string>("Digite o endereço: ")
          .PromptStyle("green"));

    int numeroConta = Clientes.Count + 1;

    var novaConta = new PessoaFisica(numeroConta, nome, cpf, nascimento, endereco);

    Clientes.AddLast(novaConta);

    AnsiConsole.MarkupLine("[green]Criado com sucesso![/]");
  }

  public void CriarPessoaJuridica()
  {
    var razaoSocial = AnsiConsole.Prompt(
      new TextPrompt<string>("Digite a razao social: ")
          .PromptStyle("green"));

     var cnpj = AnsiConsole.Prompt(
      new TextPrompt<string>("Digite o CNPJ: ")
          .PromptStyle("green"));

     var endereco = AnsiConsole.Prompt(
      new TextPrompt<string>("Digite o endereço: ")
          .PromptStyle("green"));
    
     int numeroConta = Clientes.Count + 1;

     var novaConta = new PessoaJuridica(numeroConta, razaoSocial, cnpj, endereco);

     Clientes.AddLast(novaConta);

     AnsiConsole.MarkupLine("[green]Criado com sucesso![/]");
    }
}
