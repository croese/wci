using System;

namespace npascal.frontend.pascal
{
  public class PascalScanner : Scanner
  {
    public PascalScanner(Source source) : base(source)
    {
    }

    protected override Token ExtractToken()
    {
      SkipWhitespace();

      Token token = new EofToken(Source);
      var currentChar = CurrentChar();

      if (currentChar == Source.Eof)
      {
        token = new EofToken(Source);
      }
      else if (char.IsLetter(currentChar))
      {
        token = new PascalWordToken(Source);
      }
//      else if (char.IsDigit(currentChar))
//      {
//        token = new PascalNumberToken(Source);
//      }
      else if (currentChar == '\'')
      {
        token = new PascalStringToken(Source);
      }
//      else if (PascalTokenType.SpecialSymbols.ContainsKey(currentChar.ToString()))
//      {
//        token = new PascalSpecialSymbolToken(Source);
//      }
//      else
//      {
//        token = new PascalErrorToken(Source, InvalidCharacter, currentChar.ToString());
//        NextChar();
//      }

      return token;
    }

    private void SkipWhitespace()
    {
      var currentChar = CurrentChar();

      while (char.IsWhiteSpace(currentChar) || currentChar == '{')
      {
        if (currentChar == '{')
        {
          do
          {
            currentChar = NextChar();
          } while (currentChar != '}' && currentChar != Source.Eof);

          if (currentChar == '}')
          {
            currentChar = NextChar();
          }
        }
        else
        {
          currentChar = NextChar();
        }
      }
    }
  }
}