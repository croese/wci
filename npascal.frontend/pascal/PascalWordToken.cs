using System;
using System.Text;

namespace npascal.frontend.pascal
{
  public class PascalWordToken : PascalToken
  {
    public PascalWordToken(Source source) : base(source)
    {
    }

    protected override void Extract()
    {
      var textBuffer = new StringBuilder();
      var currentChar = CurrentChar();

      while (char.IsLetterOrDigit(currentChar))
      {
        textBuffer.Append(currentChar);
        currentChar = NextChar();
      }

      Text = textBuffer.ToString();

      if (PascalTokens.ReservedWords.Contains(Text.ToLower()))
      {
        var type = (PascalTokenType) Enum.Parse(typeof(PascalTokenType), Text, true);
        Type = PascalTokens.TokenTypes[type];
      }
      else
      {
        Type = PascalTokens.TokenTypes[PascalTokenType.Identifier];
      }
    }
  }
}