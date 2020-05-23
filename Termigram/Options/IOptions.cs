using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Telegram.Bot.Types.Enums;
using Termigram.CommandExtractors;
using Termigram.CommandInvokers;
using Termigram.CommandLinkers;
using Termigram.CommandParsers;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.ResultProcessors;
using Termigram.SpecialValueProviders;

namespace Termigram.Options
{
    public interface IOptions
    {
        string Token { get; }

        TimeSpan CancellationCheckInterval { get; }

        HttpClient? HttpClient { get; }

        IWebProxy? Proxy { get; }

        ICommandExtractor CommandExtractor { get; }

        IReadOnlyList<UpdateType>? AllowedUpdates { get; }

        IReadOnlyList<ICommandParser> Parsers { get; }

        IReadOnlyList<IConverter>? Converters { get; }

        IReadOnlyList<IDefaultValueProvider>? DefaultValueProviders { get; }

        IReadOnlyList<ISpecialValueProvider>? SpecialValueProviders { get; }

        IReadOnlyList<ICommandLinker> Linkers { get; }

        ICommandInvoker CommandInvoker { get; }

        IReadOnlyList<IResultProcessor> ResultProcessors { get; }
    }
}
