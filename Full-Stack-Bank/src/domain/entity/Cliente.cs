using Spectre.Console;
using FullStackBank.Utils;
namespace FullStackBank.Domain.Entity;

public abstract class Cliente
{
    public String Nome { get; private set; }
    public DateTime DataDeNascimento { get; private set; }
    public String Email { get; private set; }
    public String Telefone { get; private set; }
    public String Endereço { get; private set; }
    public String Conta { get; private set; }
    public String Senha { get; private set; }
    public Decimal Saldo { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public DateTime AtualizadoEm { get; private set; }
    public Boolean Desativado { get; private set; }

    public virtual void ResumoCliente() {
      AnsiConsole.MarkupLine(
        $"Nome do Cliente: {Nome}" +
        $"Data de Nascimento: {String.Format("{0:dd/MM/yyyy}", DataDeNascimento)}" +
        $"Email do Cliente: {Email}" +
        $"Telefone do Cliente: {Telefone}" +
        $"Endereço do Cliente: {Endereço} \n \n" +
        $"Número da Conta: {Conta}" +
        $"Saldo: {CurrencyUtil.EmReal(Saldo)}" +
        $"Data de criação: {String.Format("{0:dd/MM/yyyy HH:mm:ss}", CriadoEm)}"
        );
    }

    private void ResumoTitulo() {
      var rule = new Rule("Resumo do Cliente");
      rule.LeftJustified();
      rule.RuleStyle("green");
      AnsiConsole.Write(rule);
    }

}
