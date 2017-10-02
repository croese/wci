using System;
using System.Diagnostics;
using System.IO;
using CommandLine;
using npascal.backend;
using npascal.frontend;
using Parser = CommandLine.Parser;

namespace npascal
{
  public class Options
  {
    // TODO: figure out better way to constrain the acceptable Operation values
    [Value(0, Required = true, HelpText = "Operation", MetaName = "compile|execute")]
    public string Operation { get; set; }

    [Value(1, Required = true, HelpText = "Source file path", MetaName = "source file path")]
    public string SourceFilePath { get; set; }

    [Option('i', HelpText = "intermediate")]
    public bool Intermediate { get; set; }

    [Option('x', HelpText = "cross-reference")]
    public bool CrossReference { get; set; }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var result = Parser.Default.ParseArguments<Options>(args);
      result.WithParsed(o =>
      {
        try
        {
          var source = new Source(new StreamReader(o.SourceFilePath));
          source.AddMessageListener(new SourceMessageListener());

          var parser = FrontendFactory.CreateParser("pascal", "top-down", source);
          parser.AddMessageListener(new ParserMessageListener());

          var backend = BackendFactory.CreateBackend(o.Operation);
          backend.AddMessageListener(new BackendMessageListener());

          parser.Parse();
          source.Close();

          var iCode = parser.IntermediateCode;
          var symTab = parser.SymbolTable;

          backend.Process(iCode, symTab);
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
        }
      });
    }
  }
}