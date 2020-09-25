using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace KamibotConsole
{
    public static class DiscordEventHandler
    {
        public static Task Subscribe()
        {
            Context.Client.Log += Log;
            Context.Client.MessageReceived += MessageReceived;
            return Task.CompletedTask;
        }

        public static Task Unsubscribe()
        {
            Context.Client.Log -= Log;
            Context.Client.MessageReceived -= MessageReceived;
            return Task.CompletedTask;
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private static async Task MessageReceived(SocketMessage message)
        {
            await DiscordCommandHandler.RunCommand(message);
        }
    }
}
