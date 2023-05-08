using Spectre.Console;
using FullStackBank.Utils;
namespace FullStackBank.Domain.Entity;

public abstract class Cliente
{
    public long Id { get; protected set; }
    public String Nome { get; protected set; }
    public String Email { get; protected set; }
    public String Telefone { get; protected set; }
    public String Endereço { get; protected set; }
    public String Conta { get; protected set; }
    public String Senha { get; protected set; }
    public Decimal Saldo { get; protected set; }
    public DateTime CriadoEm { get; protected set; }
    public DateTime AtualizadoEm { get; protected set; }
    public Boolean Desativado { get; protected set; }

    public virtual void ResumoCliente() {
      AnsiConsole.MarkupLine(
        $"Nome do Cliente: {Nome} \n" +
        $"Email do Cliente: {Email} \n" +
        $"Telefone do Cliente: {Telefone} \n" +
        $"Endereço do Cliente: {Endereço} \n \n \n" +
        $"Número da Conta: {Conta}\n" +
        $"Saldo: {CurrencyUtil.EmReal(Saldo)}\n" +
        $"Data de criação da Conta: {String.Format("{0:dd/MM/yyyy HH:mm:ss}", CriadoEm)}\n"
        );
    }

    protected void ResumoTitulo() {
      var rule = new Rule("Resumo do Cliente");
      rule.LeftJustified();
      rule.RuleStyle("green");
      AnsiConsole.Write(rule);
    }

}
