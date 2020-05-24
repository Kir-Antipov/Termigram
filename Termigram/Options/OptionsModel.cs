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
using Termigram.Extensions;
using Termigram.ResultProcessors;
using Termigram.SpecialValueProviders;
using Termigram.State;

namespace Termigram.Options
{
    public class OptionsModel
    {
        public string? Token { get; }

        public TimeSpan? CancellationCheckInterval { get; }

        public HttpClient? HttpClient { get; }

        public IWebProxy? Proxy { get; }

        public Func<IState>? StateFactory { get; }

        public ICommandExtractor? CommandExtractor { get; }

        public IReadOnlyList<UpdateType>? AllowedUpdates { get; }

        public IReadOnlyList<ICommandParser>? Parsers { get; }

        public IReadOnlyList<IConverter>? Converters { get; }

        public IReadOnlyList<IDefaultValueProvider>? DefaultValueProviders { get; }

        public IReadOnlyList<ISpecialValueProvider>? SpecialValueProviders { get; }

        public IReadOnlyList<ICommandLinker>? Linkers { get; }

        public ICommandInvoker? CommandInvoker { get; }

        public IReadOnlyList<IResultProcessor>? ResultProcessors { get; }

        public OptionsModel(string? token, TimeSpan? cancellationCheckInterval, HttpClient? httpClient, IWebProxy? proxy, Func<IState>? stateFactory, ICommandExtractor? commandExtractor, IEnumerable<UpdateType>? allowedUpdates, IEnumerable<ICommandParser>? parsers, IEnumerable<IConverter>? converters, IEnumerable<IDefaultValueProvider>? defaultValueProviders, IEnumerable<ISpecialValueProvider>? specialValueProviders, IEnumerable<ICommandLinker>? linkers, ICommandInvoker? commandInvoker, IEnumerable<IResultProcessor>? resultProcessors)
        {
            Token = token;
            CancellationCheckInterval = cancellationCheckInterval;
            HttpClient = httpClient;
            Proxy = proxy;
            StateFactory = stateFactory;
            CommandExtractor = commandExtractor;
            AllowedUpdates = allowedUpdates.AsReadOnlyListOrDefault();
            Parsers = parsers.AsReadOnlyListOrDefault();
            Converters = converters.AsReadOnlyListOrDefault();
            DefaultValueProviders = defaultValueProviders.AsReadOnlyListOrDefault();
            SpecialValueProviders = specialValueProviders.AsReadOnlyListOrDefault();
            Linkers = linkers.AsReadOnlyListOrDefault();
            CommandInvoker = commandInvoker;
            ResultProcessors = resultProcessors.AsReadOnlyListOrDefault();
        }
    }
}
