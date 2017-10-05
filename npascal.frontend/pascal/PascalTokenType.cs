namespace npascal.frontend.pascal
{
  public enum PascalTokenType
  {
    And,
    Array,
    Begin,
    Case,
    Const,
    Div,
    Do,
    Downto,
    Else,
    End,
    File,
    For,
    Function,
    Goto,
    If,
    In,
    Label,
    Mod,
    Nil,
    Not,
    Of,
    Or,
    Packed,
    Procedure,
    Program,
    Record,
    Repeat,
    Set,
    Then,
    To,
    Type,
    Until,
    Var,
    While,
    With,

    [TokenType("+")] Plus,
    [TokenType("-")] Minus,
    [TokenType("*")] Star,
    [TokenType("/")] Slash,
    [TokenType(":=")] ColonEquals,
    [TokenType(".")] Dot,
    [TokenType(",")] Comma,
    [TokenType(";")] Semicolon,
    [TokenType(":")] Colon,
    [TokenType("'")] Quote,
    [TokenType("=")] Equals,
    [TokenType("<>")] NotEquals,
    [TokenType("<")] LessThan,
    [TokenType("<=")] LessEquals,
    [TokenType(">=")] GreaterEquals,
    [TokenType(">")] GreaterThan,
    [TokenType("(")] LeftParen,
    [TokenType(")")] RightParen,
    [TokenType("[")] LeftBracket,
    [TokenType("]")] RightBracket,
    [TokenType("{")] LeftBrace,
    [TokenType("}")] RightBrace,
    [TokenType("^")] UpArrow,
    [TokenType("..")] DotDot,

    Identifier,
    Integer,
    Real,
    String,
    Error,
    EndOfFile
  }

  public class TokenTypeMetadata : ITokenType
  {
    public string Text { get; }

    public TokenTypeMetadata(string text)
    {
      Text = text;
    }

    public override string ToString()
    {
      return Text.ToUpper();
    }
  }
}