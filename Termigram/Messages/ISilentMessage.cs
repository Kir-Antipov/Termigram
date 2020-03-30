namespace Termigram.Messages
{
    public interface ISilentMessage : IMessage
    {
        bool DisableNotification { get; }
    }
}
