using Discord.WebSocket;
using KamibotConsole.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KamibotConsole
{
    public static class Context
    {
        public static readonly DiscordSocketClient Client = new DiscordSocketClient();
        public static Guild Guild { get; set; }
        public static Dictionary<string, string> CharacterDictionary => GetCharacterDict();
        public static Dictionary<string, string> CommandDictionary => GetCommandDict();
        public static List<Character> Characters { get; set; } = new List<Character>();
        public static bool IsRunning { get; set; } = true;
        public static bool IsBuilding { get; set; } = false;
        public static bool IsInitialized { get; set; } = false;
        public static bool HasCharChannels { get; set; } = false;

        public static Task Initialize()
        {
            Thread.Sleep(3000);
            Guild = new Guild(758809716192837672, Client.GetGuild(758809716192837672));
            foreach (var character in CharacterDictionary)
            {
                Context.Characters.Add(new Character()
                {
                    Name = character.Key,
                    HashTag = character.Value,
                });
            }
            IsInitialized = true;
            return Task.CompletedTask;
        }

        private static Dictionary<string, string> GetCharacterDict()
        {
            return new Dictionary<string, string>()
            {
                { "android16", "#DBFZ_A16" },
                { "broly", "#DBFZ_BRO" },
                { "gogeta-ssgss", "#DBFZ_GTA" },
                { "goku-ultra-instinct", "#DBFZ_GUI" },
                { "jiren", "#DBFZ_JRN" },
                { "nappa", "#DBFZ_NAP" },
                { "vegeta-ssgss", "#DBFZ_BVG" }
            };
        }

        private static Dictionary<string, string> GetCommandDict()
        {
            return new Dictionary<string, string>();
        }
    }
}
