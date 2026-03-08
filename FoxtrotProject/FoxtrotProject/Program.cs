using DotNetEnv;
using Telegram.Bot;

Env.Load("../../../.env");

string token = Environment.GetEnvironmentVariable("TELEGRAM_TOKEN");

var bot = new TelegramBotClient(token);

var me = await bot.GetMe();

Console.WriteLine($"Bot conectado: @{me.Username}");