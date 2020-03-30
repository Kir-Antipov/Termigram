using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Termigram.Messages
{
    public interface IMediaMessage : IMessage<InputOnlineFile>, IReplyMessage, ISilentMessage, IMarkupMessage
    {
        string? Caption { get; }
        ParseMode ParseMode { get; }
    }
}
