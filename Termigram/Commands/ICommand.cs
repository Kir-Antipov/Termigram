using Telegram.Bot.Types;

namespace Termigram.Commands
{
    public interface ICommand
    {
        string Name { get; }

        Update Update { get; }
    }
}
