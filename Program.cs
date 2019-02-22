using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TBot
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main()
        {
            botClient = new TelegramBotClient("709032790:AAHF0ekIY51LSK58UCEKQvwmNtE73ATzTJc");

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "/start")
            {
                Console.WriteLine($"Satrt messaging in chat {e.Message.Chat.Id}.");
                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: "Ну че, драсте, я говеный попугай который только повтряет сообщеня, напишы ченибуть, хуле"
                );
            }
            else if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: "Че ты там спизданул?:\n" + e.Message.Text
                );
            }
            
        }
    }
    
}
