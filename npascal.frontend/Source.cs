using System;
using System.IO;

namespace npascal.frontend
{
  public class Source
  {
    public const char EOL = '\n';
    public const char EOF = (char) 0;

    private TextReader reader;
    private string line;
    private int lineNumber;
    private int currentPosition;

    public Source(TextReader reader)
    {
      lineNumber = 0;
      currentPosition = -2;
      this.reader = reader;
    }

    public char CurrentChar()
    {
      if (currentPosition == -2)
      {
        ReadLine();
        return NextChar();
      }
      else if (line == null)
      {
        return EOF;
      }
      else if (currentPosition == -1 || currentPosition == line.Length)
      {
        return EOL;
      }
      else if (currentPosition > line.Length)
      {
        ReadLine();
        return NextChar();
      }
      else
      {
        return line[currentPosition];
      }
    }

    public char NextChar()
    {
      currentPosition++;
      return CurrentChar();
    }

    public char PeekChar()
    {
      CurrentChar();
      if (line == null)
      {
        return EOF;
      }

      var nextPosition = currentPosition + 1;
      return nextPosition < line.Length ? line[nextPosition] : EOL;
    }

    private void ReadLine()
    {
      line = reader.ReadLine();
      currentPosition = -1;

      if (line != null)
      {
        lineNumber++;
      }
    }

    public void Close() // TODO: IDisposable?
    {
      reader?.Close();
    }

    public int GetLineNumber()
    {
      return lineNumber;
    }

    public int GetPosition()
    {
      return currentPosition;
    }
  }
}