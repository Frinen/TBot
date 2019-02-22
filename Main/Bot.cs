using System;
using System.Collections.Generic;
using System.Text;
using TBot.Actions;
using Telegram.Bot;

namespace TBot.Main
{
    public static class Bot
    {
        public static readonly ITelegramBotClient Client;

        static Bot()
        {
            Client = new TelegramBotClient(Configuration.Token);

            Bot.Client.OnMessage += Request.Message;
            Bot.Client.StartReceiving();
        }
    }
}
