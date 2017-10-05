using System;
using System.Text;

namespace npascal.frontend.pascal
{
  public class PascalStringToken : PascalToken
  {
    public PascalStringToken(Source source) : base(source)
    {
    }

    protected override void Extract()
    {
      var textBuffer = new StringBuilder();
      var valueBuffer = new StringBuilder();

      var currentChar = NextChar();
      textBuffer.Append('\'');

      do
      {
        if (char.IsWhiteSpace(currentChar))
        {
          currentChar = ' ';
        }

        if (currentChar != '\'' && currentChar != Source.Eof)
        {
          textBuffer.Append(currentChar);
          valueBuffer.Append(currentChar);
          currentChar = NextChar();
        }

        if (currentChar == '\'')
        {
          while (currentChar == '\'' && PeekChar() == '\'')
          {
            textBuffer.Append("''");
            valueBuffer.Append(currentChar);
            currentChar = NextChar();
            currentChar = NextChar();
          }
        }
      } while (currentChar != '\'' && currentChar != Source.Eof);

      if (currentChar == '\'')
      {
        NextChar();
        textBuffer.Append('\'');
        Type = PascalTokens.TokenTypes[PascalTokenType.String];
        Value = valueBuffer.ToString();
      }
      else
      {
        Type = PascalTokens.TokenTypes[PascalTokenType.Error];
        Value = PascalErrorCode.UnexpectedEof;
      }

      Text = textBuffer.ToString();
    }
  }
}