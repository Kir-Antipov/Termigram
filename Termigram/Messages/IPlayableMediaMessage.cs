namespace Termigram.Messages
{
    public interface IPlayableMediaMessage : IMediaMessage
    {
        int Duration { get; }
    }
}
