namespace npascal.message
{
  public enum MessageType
  {
    SourceLine,
    SyntaxError,
    ParserSummary,
    InterpreterSummary,
    CompilerSummary,
    Miscellaneous,
    Token,
    Assign,
    Fetch,
    Breakpoint,
    RuntimeError,
    Call,
    Return
  }
}