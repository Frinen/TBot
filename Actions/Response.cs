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
            if(e.Message.Type == MessageType.Location)
            {
                await ReciveLocation(e);
            }
            else if (e.Message.Type == MessageType.Contact)
            {
                await ReciveContact(e);
            }
            else
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
                    case "купити":
                        {
                            await Buy(e);
                            break;
                        }
                    case "продати":
                        {
                            await Sell(e);
                            break;
                        }
                    case "/location":
                        {
                            await SendLocation(e, message.Message);
                            break;
                        }
                    case "головна":
                        {
                            await Greatings(e);
                            break;
                        }
                    case "шевченківський":
                        {
                            await SubLaocation(e);
                            break;
                        }
                    case "першотравневий":
                        {
                            await SubLaocation(e);
                            break;
                        }
                    case "садгірський":
                        {
                            await SubLaocation(e);
                            break;
                        }
                    case "підрайон1":
                        {
                            await Apartment(e);
                            break;
                        }
                    case "підрайон2":
                        {
                            await Apartment(e);
                            break;
                        }
                    case "дім":
                        {
                            await SendHomeLocation(e, "");
                            break;
                        }
                    case "квартира":
                        {
                            await SendApartment(e);
                            break;
                        }
                    case "1":
                        {
                            await SendHomeLocation(e, "1");
                            break;
                        }
                    case "2":
                        {
                            await SendHomeLocation(e, "2");
                            break;
                        }
                    case "3":
                        {
                            await SendHomeLocation(e, "3");
                            break;
                        }
                    case "4":
                        {
                            await SendHomeLocation(e, "1");
                            break;
                        }
                    case "5":
                        {
                            await SendHomeLocation(e, "1");
                            break;
                        }
                    case "6":
                        {
                            await SendHomeLocation(e, "1");
                            break;
                        }
                    case "7":
                        {
                            await SendHomeLocation(e, "1");
                            break;
                        }
                    case "8":
                        {
                            await SendHomeLocation(e, "1");
                            break;
                        }
                    case "9":
                        {
                            await SendHomeLocation(e, "1");
                            break;
                        }
                    default:
                        {
                            await BadRequest(e);
                            break;
                        }

                }
            }
            

        }

        private async static Task Greatings(MessageEventArgs e)
        {
            Console.WriteLine($"Satrt messaging in chat {e.Message.Chat.Id}.");

            var rkm = new ReplyKeyboardMarkup();

            rkm.Keyboard =
             new KeyboardButton[][]
             {
                new KeyboardButton[]{ new KeyboardButton("Купити") },
                new KeyboardButton[]{new KeyboardButton("Продати")},
             };
            rkm.ResizeKeyboard = true;

            await Bot.Client.SendTextMessageAsync(e.Message.Chat.Id, "Що ви хочете зробити?", ParseMode.Html, false, false, 0, rkm);
            
        }

        private async static Task Buy(MessageEventArgs e)
        {
            Console.WriteLine($"Buy menue in chat {e.Message.Chat.Id}.");

            var buyMenue = new ReplyKeyboardMarkup();

            buyMenue.Keyboard =
             new KeyboardButton[][]
             {
                new KeyboardButton[]{ new KeyboardButton("Першотравневий")},
                new KeyboardButton[]{new KeyboardButton("Садгірський")},
                new KeyboardButton[]{new KeyboardButton("Шевченківський")},
                new KeyboardButton[]{ new KeyboardButton("Головна") }
             };
            buyMenue.ResizeKeyboard = true;

            await Bot.Client.SendTextMessageAsync(e.Message.Chat.Id, "Оберіть район", ParseMode.Html, false, false, 0, buyMenue);

        }

        private async static Task SubLaocation(MessageEventArgs e)
        {
            Console.WriteLine($"Buy menue in chat {e.Message.Chat.Id}.");

            var buyMenue = new ReplyKeyboardMarkup();

            buyMenue.Keyboard =
             new KeyboardButton[][]
             {
                new KeyboardButton[]{ new KeyboardButton("Підрайон1")},
                new KeyboardButton[]{new KeyboardButton("Підрайон2") },
                new KeyboardButton[]{ new KeyboardButton("Головна") }
             };
            buyMenue.ResizeKeyboard = true;

            await Bot.Client.SendTextMessageAsync(e.Message.Chat.Id, "Оберіть підрайон", ParseMode.Html, false, false, 0, buyMenue);

        }

        private async static Task Sell(MessageEventArgs e)
        {
            Console.WriteLine($"Select type in chat {e.Message.Chat.Id}.");

            var back = new ReplyKeyboardMarkup();

           back.Keyboard =
            new KeyboardButton[][]
            {
                 new KeyboardButton[]{ new KeyboardButton("Дім")},
                 new KeyboardButton[]{ new KeyboardButton("Квартира")},
                new KeyboardButton[]{ new KeyboardButton("Головна") },
            };
            back.ResizeKeyboard = true;

            await Bot.Client.SendTextMessageAsync(replyToMessageId: e.Message.MessageId,
                chatId: e.Message.Chat,
                text: "Вкажіть тип нерухомості",
                replyMarkup: back);

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

        private async static Task SendLocation(MessageEventArgs e, string location)
        {
            if (location == null )
            {
                await Bot.Client.SendTextMessageAsync(e.Message.Chat.Id, "Wrong location" );
                
            }
            else
            {
                await Bot.Client.SendTextMessageAsync(e.Message.Chat.Id, $"Your location {location}");
            }

            Console.WriteLine($"recive location in chat {e.Message.Chat.Id}.");
            //await Bot.Client.SendLocationAsync(
            //  chatId: e.Message.Chat,
            //  latitude: (float)latitude,
            //  longitude: (float)longitude,
            //  replyToMessageId: e.Message.MessageId

            //);
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
        private async static Task Apartment(MessageEventArgs e)
        {
            Console.WriteLine($"Send appartment in chat {e.Message.Chat.Id}.");
            await Bot.Client.SendPhotoAsync(
                chatId: e.Message.Chat,
                photo: "http://homeandstyle.com.ua/wp-content/uploads/2017/10/cheerful-house-exterior-color-idea-with-orange-wall-design-chic-inspiration-white-gray-black-window-frames_exterior-paint-colors-with-red-brick_interior-designer-homes-hous.jpg",
                caption: "<b>Котедж</b>. <i>вул. вулиця 1</i>",
                parseMode: ParseMode.Html
                );
          
            var back = new ReplyKeyboardMarkup();

            back.Keyboard =
             new KeyboardButton[][]
             {
                new KeyboardButton[]{ new KeyboardButton("Головна") }
             };
            back.ResizeKeyboard = true;
            await Bot.Client.SendTextMessageAsync(
               replyToMessageId: e.Message.MessageId,
               chatId: e.Message.Chat,
               parseMode: ParseMode.Markdown,
               text: "Реєлтор Іван Іванов +88005553535",
               replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl(
                  "Подивитись на карті",
                   "https://www.google.com/maps/place/%D0%B1%D1%83%D0%BB.+%D0%93%D0%B5%D1%80%D0%BE%D0%B5%D0%B2+%D0%9A%D1%80%D1%83%D1%82,+%D0%A7%D0%B5%D1%80%D0%BD%D0%BE%D0%B2%D1%86%D1%8B,+%D0%A7%D0%B5%D1%80%D0%BD%D0%BE%D0%B2%D0%B8%D1%86%D0%BA%D0%B0%D1%8F+%D0%BE%D0%B1%D0%BB%D0%B0%D1%81%D1%82%D1%8C,+58000/@48.2746573,25.9150428,15z/data=!4m5!3m4!1s0x47340ed647695a45:0x33117ca11f2f5873!8m2!3d48.2545416!4d25.9536881"
                 ))
           );
            await Bot.Client.SendTextMessageAsync(replyToMessageId: e.Message.MessageId,
               chatId: e.Message.Chat,
               text: "Що далі?",
               replyMarkup: back);
        }
        private async static Task SendApartment(MessageEventArgs e)
        {
            Console.WriteLine($"Send appartment in chat {e.Message.Chat.Id}.");
            var appartment = new ReplyKeyboardMarkup();

            appartment.Keyboard =
             new KeyboardButton[][]
             {
                 new KeyboardButton[]{ new KeyboardButton("1"), new KeyboardButton("2"), new KeyboardButton("3") },
                 new KeyboardButton[]{ new KeyboardButton("4"), new KeyboardButton("5"), new KeyboardButton("6") },
                 new KeyboardButton[]{ new KeyboardButton("7"), new KeyboardButton("8"), new KeyboardButton("9") },
             };
            appartment.ResizeKeyboard = true;

            await Bot.Client.SendTextMessageAsync(replyToMessageId: e.Message.MessageId,
                chatId: e.Message.Chat,
                text: "Поверх",
                replyMarkup: appartment);
        }
        private async static Task SendHomeLocation(MessageEventArgs e, string floor)
        {
            Console.WriteLine($"Send locaion in chat {e.Message.Chat.Id}.");
            var appartment = new ReplyKeyboardMarkup();

            appartment.Keyboard =
             new KeyboardButton[][]
             {
                 new KeyboardButton[]{ new KeyboardButton("Головна") }
             };
            appartment.ResizeKeyboard = true;
            if (floor == null || floor =="")
            {
                await Bot.Client.SendTextMessageAsync(replyToMessageId: e.Message.MessageId,
                    chatId: e.Message.Chat,
                    text: "Відправте локацію будинку ",
                    replyMarkup: appartment);
            }
            else
            {
                await Bot.Client.SendTextMessageAsync(replyToMessageId: e.Message.MessageId,
                    chatId: e.Message.Chat,
                    text: "Відправте локацію квартири ",
                    replyMarkup: appartment);
            }
        }
        private async static Task ReciveLocation(MessageEventArgs e )
        {
            var appartment = new ReplyKeyboardMarkup();

            appartment.Keyboard =
             new KeyboardButton[][]
             {
                 new KeyboardButton[]{ new KeyboardButton("Головна") }
             };
            appartment.ResizeKeyboard = true;
            Console.WriteLine($"Recive locaion from chat {e.Message.Chat.Id}.");
            await Bot.Client.SendTextMessageAsync(replyToMessageId: e.Message.MessageId,
                    chatId: e.Message.Chat,
                    text: "Локація отримана, відправте свої контакти",
                    replyMarkup: appartment);
        }
        private async static Task ReciveContact(MessageEventArgs e)
        {
            var appartment = new ReplyKeyboardMarkup();

            appartment.Keyboard =
             new KeyboardButton[][]
             {
                 new KeyboardButton[]{ new KeyboardButton("Головна") }
             };
            appartment.ResizeKeyboard = true;
            Console.WriteLine($"Recive contact from chat {e.Message.Chat.Id}.");
            await Bot.Client.SendTextMessageAsync(replyToMessageId: e.Message.MessageId,
                    chatId: e.Message.Chat,
                    text: "Контакт отримано",
                    replyMarkup: appartment);
        }
    }
}
