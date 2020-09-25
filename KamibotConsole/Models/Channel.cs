using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace KamibotConsole.Models
{
    public class Channel
    {
        public Channel(RestChannel restChannel, string name)
        {
            RestChannel = restChannel;
            Id = restChannel.Id;
            Name = name;
        }

        /*public Channel(SocketChannel schannel, string name)
        {
            SChannel = schannel;
            Name = name;
            Id = schannel.Id;
        }*/

        public ulong Id { get; set; }
        public string Name { get; set; }
        public ulong? CategoryId { get; set; }
        public RestChannel RestChannel { get; set; }
    }
}
