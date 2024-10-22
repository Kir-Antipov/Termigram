﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;
using Termigram.Options;

#pragma warning disable CS1998

namespace Termigram.Example
{
    [Bot(Bindings.AnyPublic)]
    public class TestBot : StateBotBase
    {
        private readonly IReplyMarkup MainMenu;

        public TestBot(IStateOptions options) : base(options) 
        {
            MainMenu = ReplyKeyboard().Columns(2).Build(ReplyButtons
            (
                nameof(Lucky),  nameof(Memento),
                nameof(Sum),    nameof(Sticker),
                        nameof(Help)
            ));
        }

        [DefaultCommand]
        public static string Default() => "Sorry, I have no such command";

        public TextMessage Start() =>
            new TextMessage(@"Hi! I'm a test robot created to demonstrate the capabilities of <a href=""https://github.com/Kir-Antipov/Termigram"">Termigram</a>!", replyMarkup: MainMenu);

        [Command("Sum\u00A03\u00A0values", "sum")]
        public string Sum(int a, int? b = null, int c = 1) => $"Sum of <b>{a}</b>, <b>{b ?? 0}</b> and <b>{c}</b> is {a + (b ?? 0) + c}";

        [Command("Remember\u00A0value", "memento")]
        public string Memento(User user, string? data = null)
        {
            if (data is null)
                return State.TryTakeState(user, out string? stored) ? $"You asked me to store: {stored}" : "Sorry, you didn't ask me store anything";

            State.SetState(user, data);
            return $"Stored: {data}";
        }

        public void EnterPrivateZone() => throw new UnauthorizedAccessException("Sorry, you're blacklisted!");

        public async Task EnterPrivateZoneAsync() => throw new UnauthorizedAccessException("Sorry, you're blacklisted!");

        [Command("Guess\u00A0the\u00A0number", "lucky")]
        public async IAsyncEnumerable<TextMessage> Lucky(User user)
        {
            const int min = 1;
            const int max = 10;

            int guessed = new Random().Next(min, max + 1);

            yield return "Let's see how lucky you are!";
            yield return $@"I've made a number from <b>{min}</b> to <b>{max}</b>. Try to guess it!";

            string? userAssumption = await WaitForAnswerAsync(user);

            if (string.IsNullOrEmpty(userAssumption))
                throw new TimeoutException("Sorry, but you haven't answered for too long. Let's play next time!");

            if (userAssumption.Trim() == guessed.ToString())
            {
                yield return "Lucky guy!";
            }
            else
            {
                yield return $@"This time you're out of luck. I figured out the number <b>{guessed}</b>";
            }
        }

        [Command("Send\u00A0sticker", "sticker")]
        public StickerMessage Sticker() => new StickerMessage("CAACAgIAAxkBAAIzjV5x6DLZatZVMyk7ZJJUUV4fanS6AALIAAPXawQWhI2aNfW4CsgYBA");

        public string Help() => "Just do whatever you want :)";

        public string Overload(DateTime? date) => $"Date: {date}";

        public string Overload(string begin, string end) => $"Messages: \"{begin}\" & \"{end}\"";

        public string Overload(int number) => $"Number: {number}";

        public string Overload(string message) => $"Message: \"{message}\"";
    }
}
