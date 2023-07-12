using CLI.BANK.Utils;
using Spectre.Console;
using CLI.BANK.Enums;

namespace CLI.BANK.Entities;

internal class PessoaFisica : Cliente
{
  public string CPF { get; private set; }
  public DateOnly DataNascimento { get; private set; }

  public PessoaFisica(
      int numeroConta, 
      string nome, 
      string cpf, 
      DateOnly dataNascimento, 
      string endereco) : base(
          numeroConta, 
          TipoDeContaEnum.PESSOA_FISICA, 
          nome, 
          endereco)
  {
    if (!RegexConst.CpfDocumentRegex().Match(cpf).Success)
      throw new Exception("Insira um CPF válido");

    if (!EhMaior(dataNascimento))
      throw new Exception("O cliente deve ser maior de idade para abrir uma conta.");

    CPF = cpf;
    DataNascimento = dataNascimento;

  }

  public bool EhMaior(DateOnly nascimento)
  {
    var hoje = DateTime.Today;
    var idade = hoje.Year - nascimento.Year;

    if (nascimento > DateOnly.FromDateTime(hoje.AddYears(-idade)))
    {
      idade--;
    }

    return idade >= 18;
  }

  public override void ResumoCliente()
  {
    AnsiConsole.Clear();

    var grid = new Grid();

    grid.AddColumn();
    grid.AddColumn();
    grid.AddColumn();
    grid.AddColumn();
    grid.AddColumn();
    grid.AddColumn();


    grid.AddRow(new Text[]{
      new Text("Nome", new Style(Color.Gold3, Color.Black)).LeftJustified(),
      new Text("CPF", new Style(Color.Gold3, Color.Black)).Centered(),
      new Text("Numero Conta", new Style(Color.Gold3, Color.Black)).Centered(),
      new Text("Saldo", new Style(Color.Gold3, Color.Black)).Centered(),
      new Text("Data de Nascimento", new Style(Color.Gold3, Color.Black)).Centered(),
      new Text("Endereco", new Style(Color.Gold3, Color.Black)).RightJustified(),
    });

    grid.AddRow(new Text[]{
      new Text($"{Nome}").LeftJustified(),
      new Text($"{CPF}").Centered(),
      new Text($"{NumeroConta}").Centered(),
      new Text($"{Saldo}").Centered(),
      new Text($"{DataNascimento:dd/MM/yyyy}").Centered(),
      new Text($"{Endereco}").RightJustified(),
    });

    AnsiConsole.Write(grid);
  }
}
