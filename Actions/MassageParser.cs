using System;
using System.Collections.Generic;
using System.Text;
using TBot.Models;
using Telegram.Bot.Args;

namespace TBot.Actions
{
    public static class MassageParser
    {
        public static ParsedMessage Parse(MessageEventArgs e)
        {
            string[] massage = e.Message.Text.ToLower().Split(" ", 2);

            var paresdMessage = new ParsedMessage();
            if (massage.Length == 2)
            {
                paresdMessage.Command = massage[0];
                paresdMessage.Message = massage[1];
            }
            else
            {
                paresdMessage.Command = massage[0];
            }
            
            return paresdMessage;
        }
    }
}
