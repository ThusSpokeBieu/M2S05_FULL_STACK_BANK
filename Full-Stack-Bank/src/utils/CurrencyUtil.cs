using System.Globalization;

namespace FullStackBank.Utils;

public class CurrencyUtil
{
    public static CultureInfo Culture = CultureInfo.CreateSpecificCulture("pt-BR");

    public static String EmReal(decimal valor) {
      return valor.ToString("C", Culture);
    }
}

