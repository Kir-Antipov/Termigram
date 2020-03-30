using Telegram.Bot.Types;

namespace Termigram.Messages
{
    public interface IMessage
    {
        ChatId? ChatId { get; }
    }
}
