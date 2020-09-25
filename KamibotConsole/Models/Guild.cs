using Discord.WebSocket;
using System.Collections.Generic;

namespace KamibotConsole.Models
{
    public class Guild
    {
        public Guild(ulong id, SocketGuild sGuild)
        {
            Id = id;
            SGuild = sGuild;
            Name = sGuild.Name;
        }

        public ulong Id { get; set; }
        public string Name { get; set; }
        public SocketGuild SGuild { get; set; }
        public List<CategoryChannel> CategoryChannels { get; set; } = new List<CategoryChannel>();
    }
}
