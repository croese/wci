using System;
using System.IO;
using npascal.message;

namespace npascal.frontend
{
  public class Source : IMessageProducer
  {
    public const char Eol = '\n';
    public const char Eof = (char) 0;

    private readonly TextReader _reader;
    private string _line;
    private int _lineNumber;
    private int _currentPosition;

    private static readonly MessageHandler _messageHandler = new MessageHandler();

    public Source(TextReader reader)
    {
      _lineNumber = 0;
      _currentPosition = -2;
      this._reader = reader;
    }

    public char CurrentChar()
    {
      if (_currentPosition == -2)
      {
        ReadLine();
        return NextChar();
      }
      else if (_line == null)
      {
        return Eof;
      }
      else if (_currentPosition == -1 || _currentPosition == _line.Length)
      {
        return Eol;
      }
      else if (_currentPosition > _line.Length)
      {
        ReadLine();
        return NextChar();
      }
      else
      {
        return _line[_currentPosition];
      }
    }

    public char NextChar()
    {
      _currentPosition++;
      return CurrentChar();
    }

    public char PeekChar()
    {
      CurrentChar();
      if (_line == null)
      {
        return Eof;
      }

      var nextPosition = _currentPosition + 1;
      return nextPosition < _line.Length ? _line[nextPosition] : Eol;
    }

    private void ReadLine()
    {
      _line = _reader.ReadLine();
      _currentPosition = -1;

      if (_line != null)
      {
        _lineNumber++;
        SendMessage(new Message(MessageType.SourceLine, new object[] {_lineNumber, _line}));
      }
    }

    public void Close() // TODO: IDisposable?
    {
      _reader?.Close();
    }

    public int GetLineNumber()
    {
      return _lineNumber;
    }

    public int GetPosition()
    {
      return _currentPosition;
    }

    public void AddMessageListener(IMessageListener listener)
    {
      _messageHandler.AddListener(listener);
    }

    public void RemoveMessageListener(IMessageListener listener)
    {
      _messageHandler.RemoveListener(listener);
    }

    public void SendMessage(Message message)
    {
      _messageHandler.SendMessage(message);
    }
  }
}