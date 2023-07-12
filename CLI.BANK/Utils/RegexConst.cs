using System.Text.RegularExpressions;

namespace CLI.BANK.Utils;

public static partial class RegexConst
{
  [GeneratedRegex(RegexPatternConst.CnpjOrCpfDocument)]
  internal static partial Regex CpfOrCnpjDocumentRegex();

  [GeneratedRegex(RegexPatternConst.NotNumericalDigit)]
  internal static partial Regex NotNumericalDigit();

  [GeneratedRegex(RegexPatternConst.CpfDocument)]
  internal static partial Regex CpfDocumentRegex();

  [GeneratedRegex(RegexPatternConst.CnpjDocument)]
  internal static partial Regex CnpjDocumentRegex();
}
