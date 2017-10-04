using System;
using npascal.message;

namespace npascal.frontend.pascal
{
  public class PascalErrorHandler
  {
    private const int MaxErrors = 25;
    public int ErrorCount { get; private set; }

    public void Flag(Token token, PascalErrorCode errorCode, Parser parser)
    {
      parser.SendMessage(new Message(MessageType.SyntaxError,
        new object[]
        {
          token.LineNumber,
          token.Position,
          token.Text,
          errorCode.ToString()
        }));

      ErrorCount++;
      if (ErrorCount > MaxErrors)
      {
        AbortTranslation(PascalErrorCode.TooManyErrors, parser);
      }
    }

    public void AbortTranslation(PascalErrorCode errorCode, Parser parser)
    {
      var fatalText = $"FATAL ERROR: " + errorCode.ToString();
      parser.SendMessage(new Message(MessageType.SyntaxError,
        new object[]
        {
          0,
          0,
          "",
          fatalText
        }));

      Environment.Exit(errorCode.GetStatus());
    }
  }
}