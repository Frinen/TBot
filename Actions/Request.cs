using System;
using System.Collections.Generic;
using System.Text;
using TBot.Main;
using Telegram.Bot.Args;

namespace TBot.Actions
{
    public static class Request
    {
        public static async void Message(object sender, MessageEventArgs e)
        {
            var message = MassageParser.Parse(e);
            await Response.GetMessage(message, e);

        }
    }
}
