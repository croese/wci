using System.Collections.Generic;

namespace npascal.message
{
  public class MessageHandler
  {
    private readonly List<IMessageListener> _listeners = new List<IMessageListener>();

    public void AddListener(IMessageListener listener)
    {
      _listeners.Add(listener);
    }

    public void RemoveListener(IMessageListener listener)
    {
      _listeners.Remove(listener);
    }

    public void SendMessage(Message message)
    {
      foreach (var listener in _listeners)
      {
        listener.MessageReceived(message);
      }
    }
  }
}