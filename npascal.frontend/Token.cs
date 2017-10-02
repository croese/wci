namespace npascal.frontend
{
  public class Token
  {
    protected TokenType type;
    protected string text;
    protected object value;
    protected readonly Source source;
    protected int lineNumber;
    protected int position;

    public Token(Source source)
    {
      this.source = source;
      lineNumber = source.GetLineNumber();
      position = source.GetPosition();

      Extract();
    }

    protected virtual void Extract()
    {
      text = CurrentChar().ToString();
      value = null;

      NextChar();
    }

    protected char NextChar()
    {
      return source.NextChar();
    }

    protected char CurrentChar()
    {
      return source.CurrentChar();
    }

    protected char PeekChar()
    {
      return source.PeekChar();
    }
  }

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