using System;
using npascal.message;

namespace npascal.frontend.pascal
{
  public class PascalParserTD : Parser

  {
    public PascalParserTD(Scanner scanner) : base(scanner)
    {
    }

    public override void Parse()
    {
      var token = NextToken();
      var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

      while (!(token is EofToken))
      {
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

    public override int GetErrorCount()
    {
      return 0;
    }
  }
}