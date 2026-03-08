using DotNetEnv;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


Env.Load("../../../.env");

string token = Environment.GetEnvironmentVariable("TELEGRAM_TOKEN");

var bot = new TelegramBotClient(token);
var me = await bot.GetMe();
Console.WriteLine($"Bot conectado: @{me.Username}");