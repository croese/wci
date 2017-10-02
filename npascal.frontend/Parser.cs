using npascal.intermediate;
using npascal.message;

namespace npascal.frontend
{
  public abstract class Parser : IMessageProducer
  {
    protected static ISymbolTable symbolTable;
    protected readonly Scanner scanner;
    protected ICode iCode;
    protected static MessageHandler messageHandler = new MessageHandler();

    public Parser(Scanner scanner)
    {
      this.scanner = scanner;
    }

    public abstract void Parse();

    public abstract int GetErrorCount();

    public Token CurrentToken()
    {
      return scanner.CurrentToken;
    }

    public Token NextToken()
    {
      return scanner.NextToken();
    }

    public void AddMessageListener(IMessageListener listener)
    {
      throw new System.NotImplementedException();
    }

    public void RemoveMessageListener(IMessageListener listener)
    {
      throw new System.NotImplementedException();
    }

    public void SendMessage(Message message)
    {
      throw new System.NotImplementedException();
    }
  }
}