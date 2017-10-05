using System;

namespace npascal.frontend.pascal
{
  [AttributeUsage(AttributeTargets.Field)]
  public sealed class TokenTypeAttribute : Attribute
  {
    public string Text { get; }

    public TokenTypeAttribute(string text)
    {
      Text = text;
    }
  }
}