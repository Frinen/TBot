using System;
using System.Threading;
using TBot.Actions;
using TBot.Main;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TBot
{
    class Program
    {
        
        static void Main()
        {
            var me = Bot.Client.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
            Thread.Sleep(int.MaxValue);
        }

    }
    
}
