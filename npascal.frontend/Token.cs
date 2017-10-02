namespace npascal.frontend
{
  public class Token
  {
    protected ITokenType Type;
    protected string Text;
    protected object Value;
    protected readonly Source Source;
    public int LineNumber { get; protected set; }
    protected int Position;

    public Token(Source source)
    {
      this.Source = source;
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