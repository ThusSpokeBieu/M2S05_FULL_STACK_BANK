using System.Linq;
using FullStackBank.Domain.Entity;
using FullStackBank.Domain.Dto.PessoaFisica;
using FullStackBank.Domain.Repository.DtoList;
using FullStackBank.Domain.Validator;

namespace FullStackBank.Domain.Repository;

public class PessoaFisicaRepository
{
    private readonly PessoaFisicaValidator Validator = new PessoaFisicaValidator();

    private readonly List<PessoaFisica> PessoaFisicaDB = new List<PessoaFisica>
    {
      new PessoaFisica(1000, "1234-5", PessoaFisicaDtoList.InitialDB[0]),
      new PessoaFisica(1001, "5678-9", PessoaFisicaDtoList.InitialDB[1]),
      new PessoaFisica(1002, "9876-5", PessoaFisicaDtoList.InitialDB[2]),
    };

    public PessoaFisica? GetPessoaFisicaById(long id) {
      return PessoaFisicaDB.FirstOrDefault(pf => pf.Id == id);
    }

    public PessoaFisica? GetPessoaFisicaByConta(string conta) {
      return PessoaFisicaDB.FirstOrDefault(pf => pf.Conta == conta);
    }

    public PessoaFisica? GetPessoaFisicaByCpf(string cpf) {
      return PessoaFisicaDB.FirstOrDefault(pf => pf.Cpf == cpf);
    }

    public void AddPessoaFisica(PessoaFisicaCriarDto dto) {
      if (GetPessoaFisicaByCpf(dto.Cpf) != null) {
        throw new ArgumentException("CPF já foi cadastrado");
      } else if (!Validator.ValidarDto(dto)) {
        throw new ArgumentException("Existe algum dado inválido");
      } else {
        string conta;

        do {
          conta = GerarNumeroContaAleatorio();
        } while (GetPessoaFisicaByConta(conta) != null);

        long id = PessoaFisicaDB.Max(pf => pf.Id) + 1;

        var PessoaFisica = new PessoaFisica(id, conta, dto);
      }
    }

    private string GerarNumeroContaAleatorio()
    {
        Random random = new Random();
        int primeiroDigito = random.Next(1000, 9999);
        int segundoDigito = random.Next(0, 9);
        string numeroDeConta = $"{primeiroDigito}-{segundoDigito}";
        return numeroDeConta;
    }

}
