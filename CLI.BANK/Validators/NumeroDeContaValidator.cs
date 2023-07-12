using Spectre.Console;
using static CLI.BANK.Utils.RegexConst;

namespace CLI.BANK.Validators;
public static class NumeroDeContaValidator
{
  public static ValidationResult NumeroDeContaValidate(string conta)
  {
    if (string.IsNullOrWhiteSpace(conta)) return ValidationResult.Error("[red]Número de conta inválido. Insira um número de conta correto.[/]");
    if (conta.Length < 6) return ValidationResult.Error("[red]Número de conta inválido. O número de conta deve ter no mínimo 6 dígitos.[/]");
    if (NotNumericalDigit().IsMatch(conta)) return ValidationResult.Error("[red]Número de conta inválido, aceita-se apenas números.[/]");

    return ValidationResult.Success();
  }
}
