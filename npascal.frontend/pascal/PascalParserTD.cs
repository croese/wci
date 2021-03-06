﻿using System;
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

          if (type != PascalTokens.TokenTypes[PascalTokenType.Error])
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
      catch (IOException)
      {
        ErrorHandler.AbortTranslation(PascalErrorCode.IOError, this);
      }
    }

    public override int GetErrorCount()
    {
      return ErrorHandler.ErrorCount;
    }
  }
}