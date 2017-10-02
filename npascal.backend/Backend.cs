using npascal.intermediate;
using npascal.message;

namespace npascal.backend
{
  public abstract class Backend : IMessageProducer
  {
    protected static MessageHandler MessageHandler = new MessageHandler();
    protected ISymbolTable SymbolTable;
    protected ICode Intermediate;

    public abstract void Process(ICode iCode, ISymbolTable symbolTable);

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