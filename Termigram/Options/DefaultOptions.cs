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
        public override IReadOnlyList<IConverter>? Converters { get; }
        public override IReadOnlyList<IDefaultValueProvider>? DefaultValueProviders { get; }
        public override IReadOnlyList<ISpecialValueProvider>? SpecialValueProviders { get; }
        public override IReadOnlyList<ICommandLinker> Linkers { get; }
        public override ICommandInvoker CommandInvoker { get; }
        public override IReadOnlyList<IResultProcessor> ResultProcessors { get; }

        protected readonly OptionsModel Model;
        #endregion

        #region Init
        public DefaultOptions(string token) : this(token ?? throw new ArgumentNullException(nameof(token)), default, default) { }

        public DefaultOptions(string token, HttpClient httpClient) : this(token ?? throw new ArgumentNullException(nameof(token)), httpClient ?? throw new ArgumentNullException(nameof(httpClient)), default) { }

        public DefaultOptions(string token, IWebProxy proxy) : this(token ?? throw new ArgumentNullException(nameof(token)), default, proxy ?? throw new ArgumentNullException(nameof(proxy))) { }

        protected DefaultOptions(string token, HttpClient? httpClient, IWebProxy? proxy)
        {
            Model = OnModelCreating(new OptionsModelBuilder(token, httpClient, proxy)).Build();

            Token = Model.Token ?? throw new ArgumentNullException(nameof(Token));
            HttpClient = Model.HttpClient;
            Proxy = Model.Proxy;

            CancellationCheckInterval = Model.CancellationCheckInterval ?? throw new ArgumentNullException(nameof(CancellationCheckInterval));
            CommandExtractor = Model.CommandExtractor ?? throw new ArgumentNullException(nameof(CommandExtractor));
            AllowedUpdates = Model.AllowedUpdates;
            Parsers = Model.Parsers ?? throw new ArgumentNullException(nameof(Parsers));
            Converters = Model.Converters;
            DefaultValueProviders = Model.DefaultValueProviders;
            SpecialValueProviders = Model.SpecialValueProviders;
            Linkers = Model.Linkers ?? throw new ArgumentNullException(nameof(Linkers));
            CommandInvoker = Model.CommandInvoker ?? throw new ArgumentNullException(nameof(CommandInvoker));
            ResultProcessors = Model.ResultProcessors ?? throw new ArgumentNullException(nameof(ResultProcessors));
        }
        #endregion

        #region Functions
        protected virtual OptionsModelBuilder OnModelCreating(OptionsModelBuilder modelBuilder) => modelBuilder.SetDefaults();
        #endregion
    }
}
