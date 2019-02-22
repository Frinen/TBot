using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TBot.Main;
using TBot.Models;
using Telegram.Bot.Args;

namespace TBot.Actions
{
    public static class Response
    {
        public async static Task GetMessage(ParsedMessage message, MessageEventArgs e)
        {
            switch(message.Command)
            {
                case "/start" :
                    {
                        await Greatings(e);
                        break;
                    }
                case "/sticker":
                    {
                        await Sticker(e, message.Message);
                        break;
                    }
                default:
                    {
                        await BadRequest(e);
                        break;
                    }
            }

        }

        private async static Task Greatings(MessageEventArgs e)
        {
            Console.WriteLine($"Satrt messaging in chat {e.Message.Chat.Id}.");
            await Bot.Client.SendTextMessageAsync(
              chatId: e.Message.Chat,
              text: @"wllcome to our bot!
                       command
                       SOMETHING ELSE
                        "
            );
        }
        private async static Task BadRequest(MessageEventArgs e)
        {
            Console.WriteLine($"Bad command in chat {e.Message.Chat.Id}.");
            await Bot.Client.SendTextMessageAsync(
              chatId: e.Message.Chat,
              text: "Command uknown"
            );
        }

        private async static Task Sticker(MessageEventArgs e, string name)
        {
            string path;
            if(name!= null)
            {
                path = "https://im3.ezgif.com/tmp/ezgif-3-48e100bd6136.webp";
            }
            else
            {
                path = "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp";
            }
            Console.WriteLine($"Send sticker in chat {e.Message.Chat.Id}.");
            await Bot.Client.SendStickerAsync(
              chatId: e.Message.Chat,
              sticker: path
            );
        }
        
    }
}
