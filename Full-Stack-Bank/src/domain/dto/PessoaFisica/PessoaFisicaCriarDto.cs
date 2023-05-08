namespace FullStackBank.Domain.Dto.PessoaFisica;

public class PessoaFisicaCriarDto
{
  public PessoaFisicaCriarDto(string cpf, DateTime dataDeNascimento, string nome, string email, string telefone, string endereço, string senha)
  {
    Cpf = cpf;
    DataDeNascimento = dataDeNascimento;
    Nome = nome;
    Email = email;
    Telefone = telefone;
    Endereço = endereço;
    Senha = senha;
  }

  public String Cpf { get; private set; }
  public DateTime DataDeNascimento { get; private set; }
  public String Nome { get; private set; }
  public String Email { get; private set; }
  public String Telefone { get; private set; }
  public String Endereço { get; private set; }
  public String Senha { get; private set; }
}
