using FluentValidation;
using FullStackBank.Domain.Dto.PessoaFisica;
using Spectre.Console;

namespace FullStackBank.Domain.Validator;

public class PessoaFisicaValidator : AbstractValidator<PessoaFisicaCriarDto>
{
    public PessoaFisicaValidator() {
      RuleFor(PessoaFisicaCriarDto => PessoaFisicaCriarDto.Cpf).Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
      RuleFor(PessoaFisicaCriarDto => PessoaFisicaCriarDto.Email).EmailAddress();
      RuleFor(PessoaFisicaCriarDto => PessoaFisicaCriarDto.Nome).Length(2, 50);
      RuleFor(PessoaFisicaCriarDto => PessoaFisicaCriarDto.DataDeNascimento).NotEmpty();
      RuleFor(PessoaFisicaCriarDto => PessoaFisicaCriarDto.Endereço).Length(5, 100);
      RuleFor(PessoaFisicaCriarDto => PessoaFisicaCriarDto.Telefone).Matches(@"^(\(\d{2}\)\s)(\d{4,5}\-\d{4})$");
      RuleFor(PessoaFisicaCriarDto => PessoaFisicaCriarDto.Senha).Matches(@"^(?!.*(012|123|234|345|456|567|678|789)).*(\d)(?!\1{2})\d*(\d)(?!\2{2})\d*$");
    }

    public Boolean ValidarDto(PessoaFisicaCriarDto dto) {
      var results = Validate(dto);

      if (!results.IsValid) {
        foreach(var failure in results.Errors)
          {
            AnsiConsole.MarkupLine("[red]A propriedade " + failure.PropertyName + " falhou em sua validação. O erro foi: " + failure.ErrorMessage + "[/]");
          }

        return false;
      } else {
        return true;
      }
    }
}
