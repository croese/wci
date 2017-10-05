using System;
using System.Reflection;

namespace npascal.frontend.pascal
{
  public sealed class ErrorCodeAttribute : Attribute
  {
    public string Message { get; }
    public int Status { get; set; }

    public ErrorCodeAttribute(string message)
    {
      Message = message;
    }
  }

  public enum PascalErrorCode
  {
    [ErrorCode("Already specified in FORWARD")] AlreadyForwarded,
    [ErrorCode("Redefined identifier")] IdentifierRedefined,
    [ErrorCode("Undefined identifier")] IdentifierUndefined,
    [ErrorCode("Incompatible assignment")] IncompatibleAssignment,
    [ErrorCode("Incompatible types")] IncompatibleTypes,
    [ErrorCode("Unexpected end of file")] UnexpectedEof,

    [ErrorCode("Object I/O error", Status = -101)] IOError,
    [ErrorCode("Too many syntax errors", Status = -102)] TooManyErrors
  }

  public static class ErrorCodeExtensions
  {
    public static string GetMessage(this PascalErrorCode errorCode)
    {
      return errorCode.GetErrorCodeAttribute().Message;
    }

    public static int GetStatus(this PascalErrorCode errorCode)
    {
      return errorCode.GetErrorCodeAttribute().Status;
    }

    private static ErrorCodeAttribute GetErrorCodeAttribute(this PascalErrorCode errorCode)
    {
      var type = errorCode.GetType();
      var attribute = type.GetCustomAttribute<ErrorCodeAttribute>();
      return attribute;
    }
  }
}