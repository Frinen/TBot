using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TBot.Main;
using TBot.Models;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TBot.Actions
{
    public static class Response
    {
        public async static Task GetMessage(ParsedMessage message, MessageEventArgs e)
        {
            switch (message.Command)
            {
                case "/start":
                    {
                        await Greatings(e);
                        break;
                    }
                case "/sticker":
                    {
                        await Sticker(e, message.Message);
                        break;
                    }
                case "/map":
                    {
                        var location = MassageParser.ParseLocation(message.Message);
                        await Location(e, location.Latitude, location.Longitude);
                        break;
                    }
                case "/link":
                    {
                        await Link(e);
                        break;
                    }
                case "/photo":
                    {
                        await Photo(e);
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
              text: @"wellcome to our bot!
                       /sticker /link /map /photo
                       SOMETHING ELSE"
            );
        }
        private async static Task BadRequest(MessageEventArgs e)
        {
            Console.WriteLine($"Bad command in chat {e.Message.Chat.Id}.");
            await Bot.Client.SendTextMessageAsync(
                replyToMessageId: e.Message.MessageId,
                chatId: e.Message.Chat,
                text: "Command uknown"
            );
        }

        private async static Task Sticker(MessageEventArgs e, string name)
        {
            string path;
            if (name != null)
            {
                path = "https://im3.ezgif.com/tmp/ezgif-3-48e100bd6136.webp";
            }
            else
            {
                path = "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp";
            }
            Console.WriteLine($"Send sticker in chat {e.Message.Chat.Id}.");
            await Bot.Client.SendStickerAsync(
                replyToMessageId: e.Message.MessageId,
                chatId: e.Message.Chat,
                sticker: path
            );
        }

        private async static Task Location(MessageEventArgs e, float? latitude, float? longitude)
        {
            if (latitude == null || longitude ==null)
            {
                latitude = (float)48.2940148;
                longitude = (float)25.9382049;
            }

            Console.WriteLine($"Send location in chat {e.Message.Chat.Id}.");
            await Bot.Client.SendLocationAsync(
              chatId: e.Message.Chat,
              latitude: (float) latitude, 
              longitude: (float) longitude,
              replyToMessageId: e.Message.MessageId
              
            );
        }

        private async static Task Link(MessageEventArgs e)
        {
            Console.WriteLine($"Send link in chat {e.Message.Chat.Id}.");
            await Bot.Client.SendTextMessageAsync(
                replyToMessageId: e.Message.MessageId,
                chatId: e.Message.Chat, 
                parseMode: ParseMode.Markdown,
                text: "Our link",
                replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                   "Facebook",
                    "https://www.facebook.com/"
                  ))
            );
        }
        private async static Task Photo(MessageEventArgs e)
        {
            Console.WriteLine($"Send photo in chat {e.Message.Chat.Id}.");
            await Bot.Client.SendPhotoAsync(
                chatId: e.Message.Chat,
                photo: "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg",
                caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                parseMode: ParseMode.Html
                );
        }
    }
}
