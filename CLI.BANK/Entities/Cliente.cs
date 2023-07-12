using CLI.BANK.Enums;
using Spectre.Console;

namespace CLI.BANK.Entities;
internal abstract class Cliente
{
  public string Nome { get; private set; }
  public TipoDeContaEnum TipoDeConta { get; private set; }
  public int NumeroConta { get; private set; }
  public decimal Saldo { get; private set; }
  public string Endereco { get; private set; }

  public Cliente(int numeroConta, TipoDeContaEnum tipoDeConta, string nome, string endereco)
  {
    Nome = nome;
    TipoDeConta = tipoDeConta;
    NumeroConta = numeroConta;
    Saldo = 0;
    Endereco = endereco;
  }

  public virtual void ResumoCliente()
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
      new Text("Endereco", new Style(Color.Gold3, Color.Black)).RightJustified(),
    });

    grid.AddRow(new Text[]{
      new Text($"{NumeroConta}").LeftJustified(),
      new Text($"{TipoDeConta}").Centered(),
      new Text($"{Nome}").Centered(),
      new Text($"R${Saldo.ToString("N2")}").Centered(),
      new Text($"{Endereco}").RightJustified()
    });

    AnsiConsole.Write(grid);
  }

}
