using Discord.WebSocket;
using Discord;
class Zalypa
{
    public static DiscordSocketClient? client;
    static void Main(String[] args)
    {
        runBot("you token here").GetAwaiter().GetResult();
    }

    public static async Task runBot(String token)
    {
        client = new DiscordSocketClient();
        await client.LoginAsync(TokenType.Bot, token);
        await client.StartAsync();
        await client.SetGameAsync("ахуеть это говно запустилось на C#");
        client.MessageReceived += HMessage;
        await Task.Delay(Timeout.Infinite);
    }

    private static Task HMessage(SocketMessage ctx)
    {
        if (ctx.Author.IsBot) return Task.CompletedTask;
        if (ctx.Content.Equals("huy"))
        {
            ctx.Channel.SendMessageAsync("pizda");
        }
        return Task.CompletedTask;
    }
}