using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace KamibotConsole.Models
{
    public class CategoryChannel
    {
        public CategoryChannel(RestCategoryChannel restCategoryChannel)
        {
            RestCatChannel = restCategoryChannel;
            Id = restCategoryChannel.Id;
            Name = restCategoryChannel.Name;
        }

        /*public CategoryChannel(SocketChannel schannel, string name)
        {
            SCatChannel = schannel;
            Name = name;
            Id = schannel.Id;
        }*/

        public ulong Id { get; set; }
        public string Name { get; set; }
        public RestCategoryChannel RestCatChannel { get; set; }
        public List<Channel> CharacterChannels { get; set; } = new List<Channel>();
    }
}
