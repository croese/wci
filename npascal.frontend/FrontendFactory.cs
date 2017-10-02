using System;
using npascal.frontend.pascal;

namespace npascal.frontend
{
  public class FrontendFactory
  {
    public static Parser CreateParser(string language, string type, Source source)
    {
      var lang = language.ToLower();
      var t = type.ToLower();

      if (lang == "pascal" && t == "top-down")
      {
        var scanner = new PascalScanner(source);
        return new PascalParserTD(scanner);
      }
      else if (lang != "pascal")
      {
        throw new Exception($"Parser factory: invalid language '{language}'");
      }
      else
      {
        throw new Exception($"Parser factory: invalid type '{type}'");
      }
    }
  }
}