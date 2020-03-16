using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Termigram.Options;

namespace Termigram.Bot
{
    public interface IBot
    {
        IOptions Options { get; }

        ITelegramBotClient Client { get; }

        Task RunAsync(CancellationToken cancellationToken = default);
    }
}
