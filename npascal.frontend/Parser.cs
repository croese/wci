using npascal.intermediate;
using npascal.message;

namespace npascal.frontend
{
  public abstract class Parser : IMessageProducer
  {
    public ISymbolTable SymbolTable { get; protected set; }
    protected readonly Scanner Scanner;
    public ICode IntermediateCode { get; protected set; }
    protected static MessageHandler MessageHandler = new MessageHandler();

    public Parser(Scanner scanner)
    {
      this.Scanner = scanner;
    }

    public abstract void Parse();

    public abstract int GetErrorCount();

    public Token CurrentToken()
    {
      return Scanner.CurrentToken;
    }

    public Token NextToken()
    {
      return Scanner.NextToken();
    }

    public void AddMessageListener(IMessageListener listener)
    {
      MessageHandler.AddListener(listener);
    }

    public void RemoveMessageListener(IMessageListener listener)
    {
      MessageHandler.RemoveListener(listener);
    }

    public void SendMessage(Message message)
    {
      MessageHandler.SendMessage(message);
    }
  }
}