using System;
using System.Text;
using npascal.frontend;
using npascal.message;

namespace npascal
{
  internal class ParserMessageListener : IMessageListener
  {
    private const int PrefixWidth = 5;

    public void MessageReceived(Message message)
    {
      var type = message.Type;
      var body = (object[]) message.Body;

      switch (type)
      {
        case MessageType.Token:
        {
          var line = (int) body[0];
          var position = (int) body[1];
          var tokenType = (ITokenType) body[2];
          var text = (string) body[3];
          var value = body[4];

          Console.WriteLine(">>> {0,-15} line={1:D3}, pos={2,2}, text=\"{3}\"",
            tokenType, line, position, text);

          if (value != null)
          {
            if (tokenType == STRING)
            {
              value = $"\"{value}\"";
            }
            Console.WriteLine($"          value={value}");
          }
          break;
        }

        case MessageType.SyntaxError:
        {
          var line = (int) body[0];
          var position = (int) body[1];
          var tokenText = (string) body[2];
          var errorMessage = (string) body[3];

          int spaceCount = PrefixWidth + position;
          var flagBuffer = new StringBuilder(new string(' ', spaceCount));
          flagBuffer.Append("^\n*** ").Append(errorMessage);

          if (tokenText != null)
          {
            flagBuffer.Append(" [at \"").Append(tokenText).Append("\"]");
          }

          Console.WriteLine(flagBuffer.ToString());
          break;
        }


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