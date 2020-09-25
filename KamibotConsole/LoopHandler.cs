using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamibotConsole
{
    public static class LoopHandler
    {
        public static async Task Monitor()
        {

            while (Context.IsRunning)
            {
                var charChannels = Context.IsInitialized ? Context.Guild?.SGuild?.CategoryChannels.FirstOrDefault(x => x.Name == "CHARACTERS") : null;

                if (ValidateCharChannels(charChannels) == true) 
                {
                    Context.HasCharChannels = true;
                    foreach (var character in Context.CharacterDictionary)
                    {
                        await CommonMethods.GetRecentTweetsBySearch(character.Value, (SocketTextChannel)charChannels.Channels.FirstOrDefault(x => x.Name == character.Key));
                    }
                }
                else if (Context.HasCharChannels && !Context.IsBuilding)
                {
                    foreach (var character in Context.CharacterDictionary)
                    {
                        await CommonMethods.GetRecentTweetsBySearch(character.Value, (RestTextChannel)Context.Guild.CategoryChannels.FirstOrDefault(x => x.Name == "CHARACTERS").CharacterChannels.FirstOrDefault(x => x.Name == character.Key).RestChannel);
                    }
                }
                await Task.Delay(300000);
            }
        }

        private static bool ValidateCharChannels(SocketCategoryChannel channel)
        {
            if (channel?.Channels != null && channel.Channels.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
