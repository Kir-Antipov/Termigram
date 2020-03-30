namespace Termigram.Messages
{
    public interface IReplyMessage
    {
        int ReplyToMessageId { get; }
    }
}
