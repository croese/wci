namespace npascal.frontend
{
  public abstract class Scanner
  {
    protected readonly Source Source;
    public Token CurrentToken { get; private set; }

    protected Scanner(Source source)
    {
      this.Source = source;
    }

    public Token NextToken()
    {
      CurrentToken = ExtractToken();
      return CurrentToken;
    }

    protected abstract Token ExtractToken();

    public char CurrentChar()
    {
      return Source.CurrentChar();
    }

    public char NextChar()
    {
      return Source.NextChar();
    }
  }
}