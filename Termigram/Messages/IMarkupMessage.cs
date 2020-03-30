using Telegram.Bot.Types.ReplyMarkups;

namespace Termigram.Messages
{
    public interface IMarkupMessage : IMessage
    {
        IReplyMarkup? ReplyMarkup { get; }
    }
}
