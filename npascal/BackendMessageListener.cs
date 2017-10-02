using System;
using npascal.message;

namespace npascal
{
  internal class BackendMessageListener : IMessageListener
  {
    public void MessageReceived(Message message)
    {
      var type = message.Type;
      var body = (object[]) message.Body;
      double elapsedTime;

      switch (type)
      {
        case MessageType.InterpreterSummary:
          var executionCount = (int) body[0];
          var runtimeErrors = (int) body[1];
          elapsedTime = (double) body[2];

          Console.WriteLine("\n{0,20} statements executed." +
                            "\n{1,20} runtime errors." +
                            "\n{2,20:F2} seconds total execution time.", executionCount,
            runtimeErrors, elapsedTime);
          break;
        case MessageType.CompilerSummary:
          var instructionCount = (int) body[0];
          elapsedTime = (double) body[1];

          Console.WriteLine("\n{0,20} instructions generated." +
                            "\n{1,20:F2} seconds total code generation time.", instructionCount,
            elapsedTime);
          break;
      }
    }
  }
}