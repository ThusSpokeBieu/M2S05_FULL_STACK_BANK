using Spectre.Console;

namespace FullStackBank.Domain.Entity;

public class PessoaFisica : Cliente
{
    public String Cpf { get; private set; }
    public DateTime DataDeNascimento { get; private set; }

    public override void ResumoCliente() {
      base.ResumoTitulo();
      AnsiConsole.MarkupLine(
        $"CPF do Cliente: {Cpf}\n" +
        $"Data de Nascimento: {String.Format("{0:dd/MM/yyyy}", DataDeNascimento)}"
      );
      base.ResumoCliente();
    }
}
