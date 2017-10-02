using System;
using npascal.message;

namespace npascal
{
  internal class SourceMessageListener : IMessageListener
  {
    public void MessageReceived(Message message)
    {
      var type = message.Type;
      var body = (object[]) message.Body;

      switch (type)
      {
        case MessageType.SourceLine:
          var lineNumber = (int) body[0];
          var lineText = (string) body[1];

          Console.WriteLine("{0:D3} {1}", lineNumber, lineText);
          break;
      }
    }
  }
}