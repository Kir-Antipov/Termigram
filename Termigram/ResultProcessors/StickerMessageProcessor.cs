using System.Threading.Tasks;
using Termigram.Bot;
using Termigram.Commands;
using Termigram.Extensions;
using Termigram.Messages;

namespace Termigram.ResultProcessors
{
    public class StickerMessageProcessor : ResultProcessorBase<StickerMessage>
    {
        protected override Task ProcessResultAsync(IBot bot, ICommand command, StickerMessage result) =>
            bot.Client.SendStickerAsync(result.ChatId ?? command.Update.GetChatIdOrUserId(), result.Sticker, result.DisableNotification, result.ReplyToMessageId, result.ReplyMarkup);
    }
}
