namespace npascal.frontend.pascal
{
  public class PascalScanner : Scanner
  {
    public PascalScanner(Source source) : base(source)
    {
    }

    protected override Token ExtractToken()
    {
      Token token;
      var currentChar = CurrentChar();

      if (currentChar == Source.Eof)
      {
        token = new EofToken(Source);
      }
      else
      {
        token = new Token(Source);
      }

      return token;
    }
  }
}