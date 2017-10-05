namespace npascal.frontend.pascal
{
  public class PascalErrorToken : PascalToken
  {
    public PascalErrorToken(Source source, PascalErrorCode errorCode,
      string tokenText) : base(source)
    {
      Text = tokenText;
      Type = PascalTokens.TokenTypes[PascalTokenType.Error];
      Value = errorCode;
    }

    protected override void Extract()
    {
    }
  }
}