using System.Collections.Generic;

namespace npascal.message
{
  public class MessageHandler
  {
    private Message message;
    private readonly List<IMessageListener> listeners = new List<IMessageListener>();

    public void AddListener(IMessageListener listener)
    {
      
    }
  }
}