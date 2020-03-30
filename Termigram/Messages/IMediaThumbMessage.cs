using Telegram.Bot.Types;

namespace Termigram.Messages
{
    public interface IMediaThumbMessage : IMediaMessage
    {
        InputMedia? Thumb { get; }
    }
}
