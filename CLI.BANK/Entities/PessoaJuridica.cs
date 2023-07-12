using CLI.BANK.Enums;
using Spectre.Console;

namespace CLI.BANK.Entities;
internal class PessoaJuridica : Cliente
{
    public string CNPJ { get; private set; }

    public PessoaJuridica(
        int numeroConta, 
        string nome, 
        string cnpj, 
        string endereco) : base(
            numeroConta, 
            TipoDeContaEnum.PESSOA_JURIDICA, 
            nome, 
            endereco)
    {
        CNPJ = cnpj;
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

        grid.AddRow(new Text[]{
          new Text("Razao Social", new Style(Color.Gold3, Color.Black)).LeftJustified(),
          new Text("CNPJ", new Style(Color.Gold3, Color.Black)).Centered(),
          new Text("Numero Conta", new Style(Color.Gold3, Color.Black)).Centered(),
          new Text("Saldo", new Style(Color.Gold3, Color.Black)).Centered(),
          new Text("Endereco", new Style(Color.Gold3, Color.Black)).RightJustified(),
        });

        grid.AddRow(new Text[]{
          new Text($"{Nome}").LeftJustified(),
          new Text($"{CNPJ}").Centered(),
          new Text($"{NumeroConta}").Centered(),
          new Text($"{Saldo}").Centered(),
          new Text($"{Endereco}").RightJustified(),
        });

        AnsiConsole.Write(grid);
    }
}
