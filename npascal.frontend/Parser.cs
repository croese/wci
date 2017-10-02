using npascal.intermediate;
using npascal.message;

namespace npascal.frontend
{
  public abstract class Parser : IMessageProducer
  {
    protected static ISymbolTable SymbolTable;
    protected readonly Scanner Scanner;
    protected ICode Intermediate;
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