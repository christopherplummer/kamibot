using System;
using System.Collections.Generic;
using System.Text;

namespace KamibotConsole.Models
{
    public class Character
    {
        public string Name { get; set; }
        public string HashTag { get; set; }
        public string LastTweetUrl { get; set; }
        public ulong ChannelId { get; set; }
    }
}
