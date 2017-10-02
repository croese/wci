using System;
using npascal.intermediate;
using npascal.message;

namespace npascal.backend.compiler
{
  public class CodeGenerator : Backend
  {
    public override void Process(ICode iCode, ISymbolTable symbolTable)
    {
      var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
      var elapsedTime = (DateTimeOffset.Now.ToUnixTimeMilliseconds() - startTime) / 1000.0;
      var instructionCount = 0;

      SendMessage(new Message(MessageType.CompilerSummary, new object[]
      {
        instructionCount,
        elapsedTime
      }));
    }
  }
}