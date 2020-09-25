using Discord.Rest;
using Discord.WebSocket;
using KamibotConsole.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KamibotConsole
{
    public static class DiscordCommandHandler
    {
        public static async Task RunCommand(SocketMessage message)
        {
            var messageContent = message.Content.Split();

            switch (messageContent[0])
            {
                case "!buildcharacterchannels":
                    await BuildCharacterChannels(message);
                    break;
                default:
                    break;
            }
        }

        private static async Task BuildCharacterChannels(SocketMessage message)
        {
            if (Context.HasCharChannels == true) return;
            var restChars = await Context.Guild.SGuild.CreateCategoryChannelAsync("CHARACTERS");
            Context.Guild.CategoryChannels.Add(new CategoryChannel(restChars));

            await message.Channel.SendMessageAsync("Building character channels!");
            Context.IsBuilding = true;
            Context.HasCharChannels = true;
            foreach (var kvp in Context.CharacterDictionary)
            {
                var channel = await Context.Guild.SGuild.CreateTextChannelAsync($"{kvp.Key}", x =>
                {
                    x.CategoryId = Context.Guild.CategoryChannels.FirstOrDefault(x => x.Name == "CHARACTERS").Id;
                });

                Context.Guild.CategoryChannels.FirstOrDefault(x => x.Name == "CHARACTERS").CharacterChannels.Add(new Channel(channel, kvp.Key));
                await CommonMethods.GetRecentTweetsBySearch($"{kvp.Value}", channel);
            }

            Context.IsBuilding = false;
            await message.Channel.SendMessageAsync("Character channels built!");
        }
    }
}
