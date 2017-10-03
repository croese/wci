using System;
using System.IO;
using npascal.message;

namespace npascal.frontend.pascal
{
  public class PascalParserTD : Parser
  {
    protected PascalErrorHandler ErrorHandler = new PascalErrorHandler();

    public PascalParserTD(Scanner scanner) : base(scanner)
    {
    }

    public override void Parse()
    {
      var token = NextToken();
      var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

      try
      {
        while (!(token is EofToken))
        {
          var type = token.Type;

          if (type != ERROR)
          {
            SendMessage(new Message(MessageType.Token,
              new object[]
              {
                token.LineNumber,
                token.Position,
                type,
                token.Text,
                token.Value
              }));
          }
          else
          {
            ErrorHandler.Flag(token, (PascalErrorCode) token.Value, this);
          }

          token = NextToken();
        }

        var elapsedTime = (DateTimeOffset.Now.ToUnixTimeMilliseconds() - startTime) / 1000.0;
        SendMessage(new Message(MessageType.ParserSummary, new object[]
        {
          token.LineNumber,
          GetErrorCount(),
          elapsedTime
        }));
      }
      catch (IOException e)
      {
        ErrorHandler.AbortTranslation(PascalErrorCode.IOError, this);
      }
    }

    public override int GetErrorCount()
    {
      return ErrorHandler.ErrorCount;
    }
  }

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