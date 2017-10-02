using System;
using npascal.message;

namespace npascal
{
  internal class ParserMessageListener : IMessageListener
  {
    public void MessageReceived(Message message)
    {
      var type = message.Type;
      var body = (object[]) message.Body;

      switch (type)
      {
        case MessageType.ParserSummary:
          var statementCount = (int) body[0];
          var syntaxErrors = (int) body[1];
          var elapsedTime = (double) body[2];

          Console.WriteLine("\n{0,20} source lines." +
                            "\n{1,20} syntax errors." +
                            "\n{2,20:F2} seconds total parsing time.", statementCount,
            syntaxErrors, elapsedTime);
          break;
      }
    }
  }
}