namespace npascal.frontend
{
  public class EofToken : Token
  {
    public EofToken(Source source) : base(source)
    {
    }

    protected override void Extract()
    {
    }
  }
}