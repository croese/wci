using System;
using System.Collections.Generic;
using System.Reflection;

namespace npascal.frontend.pascal
{
  public static class PascalTokens
  {
    public static Dictionary<PascalTokenType, TokenTypeMetadata> TokenTypes { get; }
      = new Dictionary<PascalTokenType, TokenTypeMetadata>();

    public static HashSet<string> ReservedWords { get; }
      = new HashSet<string>();

    public static Dictionary<string, TokenTypeMetadata> SpecialSymbols { get; }
      = new Dictionary<string, TokenTypeMetadata>();

    static PascalTokens()
    {
      InitializeTokenTypes();
      InitializeReservedWords();
      InitializeSpecialSymbols();
    }

    private static void InitializeSpecialSymbols()
    {
      int startIndex;
      int endIndex;
      startIndex = (int) PascalTokenType.Plus;
      endIndex = (int) PascalTokenType.DotDot;
      for (var i = startIndex; i <= endIndex; i++)
      {
        var t = (PascalTokenType) i;
        SpecialSymbols.Add(TokenTypes[t].Text, TokenTypes[t]);
      }
    }

    private static void InitializeReservedWords()
    {
      var startIndex = (int) PascalTokenType.And;
      var endIndex = (int) PascalTokenType.With;
      for (var i = startIndex; i <= endIndex; i++)
      {
        var t = (PascalTokenType) i;
        ReservedWords.Add(TokenTypes[t].Text.ToLower());
      }
    }

    private static void InitializeTokenTypes()
    {
      var enumValues = Enum.GetValues(typeof(PascalTokenType));
      foreach (PascalTokenType type in enumValues)
      {
        TokenTypes[type] = type.GetTokenTypeMetadata();
      }
    }

    private static T GetAttribute<T>(this Enum enumValue)
      where T : Attribute
    {
      return enumValue
        .GetType()
        .GetTypeInfo()
        .GetDeclaredField(enumValue.ToString())
        .GetCustomAttribute<T>();
    }

    private static TokenTypeMetadata GetTokenTypeMetadata(this PascalTokenType type)
    {
      var attribute = type.GetAttribute<TokenTypeAttribute>();
      if (attribute == null)
        return new TokenTypeMetadata(type.ToString().ToLower());

      return new TokenTypeMetadata(attribute.Text);
    }
  }
}