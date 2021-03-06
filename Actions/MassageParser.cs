﻿using System;
using System.Collections.Generic;
using System.Text;
using TBot.Models;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace TBot.Actions
{
    public static class MassageParser
    {
        public static ParsedMessage Parse(MessageEventArgs e)
        {
            var paresdMessage = new ParsedMessage();
            

            if (e.Message.Type == MessageType.Text)
            {
                string[] massage = e.Message.Text.ToLower().Split(" ", 2);
                if (massage.Length == 2)
                {
                    paresdMessage.Command = massage[0];
                    paresdMessage.Message = massage[1];
                }
                else
                {
                    paresdMessage.Command = massage[0];
                }
            }
            return paresdMessage;
        }
        public static Location ParseLocation(string massage)
        {
            var location = new Location();
            if (massage != null)
            {
                string[] masages = massage.Split(" ", 2);

                if (masages.Length == 2)
                {
                    try
                    {
                        location.Latitude = float.Parse(masages[0]);
                        location.Longitude = float.Parse(masages[1]);
                    }
                    catch
                    {
                        location.Massage = "Wrong cordinates";
                    }
                }
            }
            return location;
        }
    }
}
