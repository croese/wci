namespace npascal.frontend.pascal
{
  public class PascalErrorToken : PascalToken
  {
    public PascalErrorToken(Source source, PascalErrorCode errorCode,
      string tokenText) : base(source)
    {
      Text = tokenText;
      Type = ERROR;
      Value = errorCode;
    }

    protected override void Extract()
    {
    }
  }
}