using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace weather_forecast_bot
{
    public static class Configuration
    {
        public readonly static string BotToken = "1534082307:AAHLcv3ULGJwDvyqb54NoOMgm1vXzkd-mYY";

        #if USE_PROXY
        public static class Proxy
        {
            public readonly static string Host = "{PROXY_ADDRESS}";
            public readonly static int Port = 8080;
        }
        #endif
    }
    public class TelegramServices
    {
        private static Telegram.Bot.TelegramBotClient Bot;

        public TelegramServices()
        {
            #if USE_PROXY
            var Proxy = new WebProxy(Configuration.Proxy.Host, Configuration.Proxy.Port) { UseDefaultCredentials = true };
            Bot = new Telegram.Bot.TelegramBotClient(Configuration.BotToken, webProxy: Proxy);
            #else
            Bot = new Telegram.Bot.TelegramBotClient(Configuration.BotToken);
            #endif

            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnMessageEdited += BotOnMessageReceived;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            Bot.OnReceiveError += BotOnReceiveError;

            Bot.StartReceiving(Array.Empty<UpdateType>());

            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            if (message == null)
                return;

            if (message.Type == MessageType.Text)
            {
                switch (message.Text.Split(' ').First())
                {
                    case "/start":
                        await Start(message);
                        break;

                    default:
                        await Usage(message);
                        break;
                }
            }
            else if (message.Type == MessageType.Location)
            {
                await SendWheather(message);
            }
        }

        
        private static async Task Start(Message message)
        {
            string _usage = $"Weather Forecast\n" +
                            $"Technical University of Moldova\n";
            
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Settings", "1.1"),
                    InlineKeyboardButton.WithCallbackData("Get Weather", "GedDefaultWeather")
                },
            });

            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: _usage,
                replyMarkup: inlineKeyboard
            );
        }

        private static async Task SendWheather(Message message)
        {
            if (message.Type != MessageType.Location)
            {
                return;
            }
            await SendWeather(message.Chat.Id, message.Location.Latitude, message.Location.Longitude);
        }

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            switch (callbackQuery.Data)
            {
                case "GedDefaultWeather":
                        await SendWeather(callbackQuery.Message.Chat.Id);
                    break;

                default:
                    break;
            }

            // await Bot.AnswerCallbackQueryAsync(
            //     callbackQueryId: callbackQuery.Id,
            //     text: $"Success!"
            // );
        }

        private static async Task SendWeather(long chatId, double lat = 47.024512, double lon = 28.832157)
        {
            var response = WheaterServices.GetWheater(lat: lat, lon: lon);
            string text = $"Temperature: {response.fact?.temp} °C \n" +
                            $"Locality: {response.geo_object.locality?.name} \n" +
                            $"Country: {response.geo_object.country?.name} \n" +
                            $"Province: {response.geo_object.province?.name}";

            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData($"{DateTime.Now.AddDays(1).ToString("m")}", guid1.ToString()),
                    InlineKeyboardButton.WithCallbackData($"{DateTime.Now.AddDays(2).ToString("m")}", guid2.ToString()),
                    InlineKeyboardButton.WithCallbackData($"{DateTime.Now.AddDays(3).ToString("m")}", guid3.ToString()),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Get Weather", "GedDefaultWeather")
                }
            });
            var mes = await Bot.SendTextMessageAsync(
                chatId: chatId,
                text: text,
                replyMarkup: inlineKeyboard
            );
            
        }

        private static async Task Usage(Message message)
        {
            const string usage = "Usage: /start";
            await Bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: usage,
                replyMarkup: new ReplyKeyboardRemove()
            );
        }

        private static void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs chosenInlineResultEventArgs)
        {
            Console.WriteLine($"Received inline result: {chosenInlineResultEventArgs.ChosenInlineResult.ResultId}");
        }

        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message
            );
        }
    }
}