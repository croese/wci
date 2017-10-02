namespace npascal.frontend
{
  public abstract class Scanner
  {
    protected readonly Source source;
    public Token CurrentToken { get; private set; }

    protected Scanner(Source source)
    {
      this.source = source;
    }

    public Token NextToken()
    {
      CurrentToken = ExtractToken();
      return CurrentToken;
    }

    protected abstract Token ExtractToken();

    public char CurrentChar()
    {
      return source.CurrentChar();
    }

    public char NextChar()
    {
      return source.NextChar();
    }
  }
}