﻿namespace npascal.message
{
  public interface IMessageListener
  {
    void MessageReceived(Message message);
  }
}