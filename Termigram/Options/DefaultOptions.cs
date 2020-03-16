using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Telegram.Bot.Types.Enums;
using Termigram.CommandExtractors;
using Termigram.CommandInvokers;
using Termigram.CommandLinkers;
using Termigram.CommandParsers;
using Termigram.Extensions;
using Termigram.ResultProcessors;

namespace Termigram.Options
{
    public class DefaultOptions : OptionsBase
    {
        #region Var
        public override string Token { get; }
        public override HttpClient? HttpClient { get; }
        public override IWebProxy? Proxy { get; }

        public override TimeSpan CancellationCheckInterval { get; }
        public override ICommandExtractor CommandExtractor { get; }
        public override IReadOnlyList<UpdateType>? AllowedUpdates { get; }
        public override IReadOnlyList<ICommandParser> Parsers { get; }
        public override IReadOnlyList<ICommandLinker> Linkers { get; }
        public override ICommandInvoker CommandInvoker { get; }
        public override IReadOnlyList<IResultProcessor> ResultProcessors { get; }

        private static readonly TimeSpan DefaultCancellationCheckInterval = TimeSpan.FromMilliseconds(250);
        private static readonly ICommandExtractor DefaultCommandExtractor = new DefaultCommandExtractor();
        private static readonly IReadOnlyList<UpdateType>? DefaultAllowedUpdates = null;
        private static readonly IReadOnlyList<ICommandParser> DefaultParsers = TypeExtensions.LoadAllImplementationsAsReadOnlyList<ICommandParser>();
        private static readonly IReadOnlyList<ICommandLinker> DefaultLinkers = TypeExtensions.LoadAllImplementationsAsReadOnlyList<ICommandLinker>();
        private static readonly ICommandInvoker DefaultCommandInvoker = new DefaultCommandInvoker();
        private static readonly IReadOnlyList<IResultProcessor> DefaultResultProcessors = TypeExtensions.LoadAllImplementationsAsReadOnlyList<IResultProcessor>();
        #endregion

        #region Init
        public DefaultOptions(string token) : this(token, default, default) { }

        public DefaultOptions(string token, HttpClient httpClient) : this(token, httpClient, default) { }

        public DefaultOptions(string token, IWebProxy proxy) : this(token, default, proxy) { }

        protected DefaultOptions(string token, HttpClient? httpClient, IWebProxy? proxy)
        {
            Token = token;
            HttpClient = httpClient;
            Proxy = proxy;

            CancellationCheckInterval = DefaultCancellationCheckInterval;
            CommandExtractor = DefaultCommandExtractor;
            AllowedUpdates = DefaultAllowedUpdates;
            Parsers = DefaultParsers;
            Linkers = DefaultLinkers;
            CommandInvoker = DefaultCommandInvoker;
            ResultProcessors = DefaultResultProcessors;
        }
        #endregion
    }
}
