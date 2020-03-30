namespace Termigram.Messages
{
    public interface IMessage<out TContent> : IMessage where TContent : notnull
    {
        TContent Content { get; }
    }
}
