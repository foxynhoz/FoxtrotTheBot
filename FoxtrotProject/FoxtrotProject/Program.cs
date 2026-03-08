using DotNetEnv;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


Env.Load("../../../.env");

string token = Environment.GetEnvironmentVariable("TELEGRAM_TOKEN");

using var cts = new CancellationTokenSource();

var bot = new TelegramBotClient(token); //The bot itself
var me = await bot.GetMe();
Console.WriteLine($"Bot conectado: @{me.Username}");

bot.OnMessage += OnMessage;

Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
Console.ReadLine();

cts.Cancel(); // stop the bot

// method that handle messages received by the bot:
async Task OnMessage(Message msg, UpdateType type)
{
    string msgToLower = msg.Text.ToLower();

    switch (msgToLower)
    {
        case "/start":
            await bot.SendMessage(msg.Chat, "Welcome to this shit lol");
            break;

        case "/debug":
            await bot.SendMessage(msg.Chat, "Testando 1 2 3");
            break;
    }

    //if (msg.Text is "Amongus") Console.WriteLine("Sifude");	// we only handle Text messages here
    //Console.WriteLine($"Received {type} '{msg.Text}' in {msg.Chat}");
    // let's echo back received text in the chat

    //await bot.SendMessage(msg.Chat, $"{msg.From} said: {msg.Text}");
}

