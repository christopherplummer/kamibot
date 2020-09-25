using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KamibotConsole
{
    public static class CommonMethods
    {
        public static async Task GetRecentTweetsBySearch(string search, RestTextChannel channel)
        {
            var tweets = TwitterHandler.GetRecentTweetUrlsBySearch(search).OrderBy(x => x.Value);
            int i = 0;
            foreach (var tweet in tweets)
            {
                if (Context.Characters.FirstOrDefault(x => x.HashTag == search).LastTweetUrl == tweet.Key) break;
                if (i == 0) Context.Characters.FirstOrDefault(x => x.HashTag == search).LastTweetUrl = tweet.Key;

                Context.Characters.FirstOrDefault(x => x.HashTag == search).ChannelId = channel.Id;

                await channel.SendMessageAsync(tweet.Key);
                await Task.Delay(1000);
            }
        }

        public static async Task GetRecentTweetsBySearch(string search, SocketTextChannel channel)
        {
            var tweets = TwitterHandler.GetRecentTweetUrlsBySearch(search).OrderBy(x => x.Value);
            int i = 0;
            foreach (var tweet in tweets)
            {
                if (Context.Characters.FirstOrDefault(x => x.HashTag == search).LastTweetUrl == tweet.Key) break;
                if (i == 0) Context.Characters.FirstOrDefault(x => x.HashTag == search).LastTweetUrl = tweet.Key;

                Context.Characters.FirstOrDefault(x => x.HashTag == search).ChannelId = channel.Id;

                await channel.SendMessageAsync(tweet.Key);
                await Task.Delay(1000);
            }
        }

        public static async Task ClearChannels()
        {

        }

        public static async Task GetRandomRecentTweet(ISocketMessageChannel channel)
        {
            var rand = new Random();
            var tweets = TwitterHandler.TestSearch("");
            var tweet = tweets.Any() ? tweets.ElementAt(rand.Next(0, tweets.Count)) : "";
            await channel.SendMessageAsync(tweet);
        }

        public static async Task GetRandomRecentTweet(string searchQuery, ISocketMessageChannel channel)
        {
            var rand = new Random();
            var tweets = TwitterHandler.TestSearch(searchQuery ?? "");
            var tweet = tweets.Any() ? tweets.ElementAt(rand.Next(0, tweets.Count)) : "";
            await channel.SendMessageAsync(tweet);
        }

        public static Task SleepBot(string user, ISocketMessageChannel channel)
        {
            channel.SendMessageAsync($"Goodnight {user}");
            Context.Client.LogoutAsync();
            Environment.Exit(0);
            return Task.CompletedTask;
        }

        public static async Task TestCreateChannel()
        {
            var channel = await Context.Guild.SGuild.CreateTextChannelAsync("test", x =>
            {
                //x.CategoryId = Context.DefaultTextChanngelId;
            });
        }

        public static async Task TestCreateChannelMass(int channels)
        {
            for (int i = 0; i < channels; i++)
            {
                if (i == 50)
                {
                    Debug.WriteLine("Max channel size for category reached!");
                    break;
                }


            }
        }

        public static async Task TestTweetMass()
        {
            var tweets = TwitterHandler.TestSearch("#DBFZ_BDK");
            var channel = (SocketTextChannel)Context.Client.GetChannel(756993509466046596);
            foreach (var tweet in tweets.Take(10))
            {
                await channel.SendMessageAsync(tweet);
                Thread.Sleep(3000);
            }
        }
    }
}
