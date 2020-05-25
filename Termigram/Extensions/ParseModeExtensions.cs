using Telegram.Bot.Types.Enums;
using Termigram.Models;

namespace Termigram.Extensions
{
    public static class ParseModeExtensions
    {
        private static readonly HtmlTag[] HtmlTags = new HtmlTag[]
        {
            "a",
            "i", "em",
            "u", "ins",
            "pre", "code",
            "b", "strong",
            "s", "strike", "del"
        };

        private static readonly MarkdownTag[] MarkdownTags = new MarkdownTag[]
        {
            "*",
            "~",
            "_",
            "`",
            new MarkdownTag("[", "]", "(", ")")
        };

        public static ParseMode RecognizeSuitableParseMode(string? text)
        {
            if (string.IsNullOrEmpty(text))
                return ParseMode.Default;

            for (int i = 0; i < HtmlTags.Length; ++i)
                if (text.Contains(HtmlTags[i].Open) || text.Contains(HtmlTags[i].Close))
                    return ParseMode.Html;

            return ParseMode.Default;
        }
    }
}
