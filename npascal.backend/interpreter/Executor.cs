using System;
using npascal.intermediate;
using npascal.message;

namespace npascal.backend.interpreter
{
  public class Executor : Backend
  {
    public override void Process(ICode iCode, ISymbolTable symbolTable)
    {
      var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
      var elapsedTime = (DateTimeOffset.Now.ToUnixTimeMilliseconds() - startTime) / 1000.0;
      var executionCount = 0;
      var runtimeErrors = 0;

      SendMessage(new Message(MessageType.InterpreterSummary, new object[]
      {
        executionCount,
        runtimeErrors,
        elapsedTime
      }));
    }
  }
}