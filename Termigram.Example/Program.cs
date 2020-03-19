using System;
using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Options;

namespace Termigram.Example
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            string token;
            if (args is { } && args.Length > 0)
            {
                token = args[0];
            }
            else
            {
                Console.Write("Token: ");
                token = Console.ReadLine().Trim();
            }

            IBot bot = new TestBot(new DefaultStateOptions(token));
            return bot.RunAsync();
        }
    }
}
