namespace npascal.frontend
{
  public class Token
  {
    public ITokenType Type { get; protected set; }
    public string Text { get; protected set; }
    public object Value { get; protected set; }
    protected readonly Source Source;
    public int LineNumber { get; protected set; }
    public int Position { get; protected set; }

    public Token(Source source)
    {
      Source = source;
      LineNumber = source.GetLineNumber();
      Position = source.GetPosition();

      Extract();
    }

    protected virtual void Extract()
    {
      Text = CurrentChar().ToString();
      Value = null;

      NextChar();
    }

    protected char NextChar()
    {
      return Source.NextChar();
    }

    protected char CurrentChar()
    {
      return Source.CurrentChar();
    }

    protected char PeekChar()
    {
      return Source.PeekChar();
    }
  }
}