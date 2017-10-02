using System;
using npascal.backend.compiler;
using npascal.backend.interpreter;

namespace npascal.backend
{
  public class BackendFactory
  {
    public static Backend CreateBackend(string operation)
    {
      var op = operation.ToLower();

      if (op == "compile")
      {
        return new CodeGenerator();
      }
      else if (op == "execute")
      {
        return new Executor();
      }
      else
      {
        throw new Exception($"Backend factory: invalid operation: '{operation}'");
      }
    }
  }
}