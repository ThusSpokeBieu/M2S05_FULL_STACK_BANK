using Spectre.Console;
using FluentValidation.Results;
using FullStackBank.Domain.Dto.PessoaFisica;
using FullStackBank.Domain.Validator;

namespace FullStackBank.Domain.Entity;

public class PessoaFisica : Cliente
{
    public String Cpf { get; private set; }
    public DateTime DataDeNascimento { get; private set; }

    public PessoaFisica(long id, string conta, PessoaFisicaCriarDto dto ) {
      var validator = new PessoaFisicaValidator();
      if (!validator.ValidarDto(dto)) {
        throw new ArgumentException("Informações inválidas");
      } else {
        Id = id;
        Cpf = dto.Cpf;
        DataDeNascimento = dto.DataDeNascimento;
        Nome = dto.Nome;
        Email = dto.Email;
        Endereço = dto.Endereço;
        Telefone = dto.Telefone;
        Senha = dto.Senha;
        Saldo = 0m;
        CriadoEm = DateTime.Now;
        AtualizadoEm = DateTime.Now;
        Desativado = false;
        Conta = conta;
      }
    }

    public override void ResumoCliente() {
      base.ResumoTitulo();
      AnsiConsole.MarkupLine(
        $"CPF do Cliente: {Cpf}\n" +
        $"Data de Nascimento: {String.Format("{0:dd/MM/yyyy}", DataDeNascimento)}"
      );
      base.ResumoCliente();
    }    

    public int Idade() {
      DateTime hoje = DateTime.Now;
      TimeSpan diferenca = hoje - DataDeNascimento;

      double dias = diferenca.TotalDays;
      double diasPorAno = 365.25;

      return Convert.ToInt32(dias / diasPorAno);
    }

    public Boolean EhMaior() {
      return (Idade() >= 18);
    }

}
