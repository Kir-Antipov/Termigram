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
    public class OptionsModelBuilder
    {
        #region Var
        public OptionsModelValueBuilder<string?> Token { get; }

        public OptionsModelValueBuilder<TimeSpan?> CancellationCheckInterval { get; }

        public OptionsModelValueBuilder<HttpClient?> HttpClient { get; }

        public OptionsModelValueBuilder<IWebProxy?> Proxy { get; }

        public OptionsModelFactoryBuilder<IState> StateFactory { get; }

        public OptionsModelValueBuilder<ICommandExtractor?> CommandExtractor { get; }

        public OptionsModelCollectionBuilder<UpdateType> AllowedUpdates { get; }

        public OptionsModelCollectionBuilder<ICommandParser> Parsers { get; }

        public OptionsModelCollectionBuilder<IConverter> Converters { get; }

        public OptionsModelCollectionBuilder<IDefaultValueProvider> DefaultValueProviders { get; }

        public OptionsModelCollectionBuilder<ISpecialValueProvider> SpecialValueProviders { get; }

        public OptionsModelCollectionBuilder<ICommandLinker> Linkers { get; }

        public OptionsModelValueBuilder<ICommandInvoker?> CommandInvoker { get; }

        public OptionsModelCollectionBuilder<IResultProcessor> ResultProcessors { get; }
        #endregion

        #region Defaults
        private static readonly TimeSpan DefaultCancellationCheckInterval = TimeSpan.FromMilliseconds(250);

        private static readonly Func<IState> DefaultStateFactory = () => new DefaultState();

        private static readonly ICommandExtractor DefaultCommandExtractor = new DefaultCommandExtractor();

        private static readonly IEnumerable<UpdateType>? DefaultAllowedUpdates = null;

        private static readonly IEnumerable<ICommandParser> DefaultParsers = TypeExtensions.LoadAllImplementationsAsReadOnlyList<ICommandParser>();

        private static readonly IEnumerable<IConverter> DefaultConverters = TypeExtensions.LoadAllImplementationsAsReadOnlyList<IConverter>();

        private static readonly IEnumerable<IDefaultValueProvider> DefaultDefaultValueProviders = TypeExtensions.LoadAllImplementationsAsReadOnlyList<IDefaultValueProvider>();

        private static readonly IEnumerable<ISpecialValueProvider> DefaultSpecialValueProviders = TypeExtensions.LoadAllImplementationsAsReadOnlyList<ISpecialValueProvider>();

        private static readonly IEnumerable<ICommandLinker> DefaultLinkers = TypeExtensions.LoadAllImplementationsAsReadOnlyList<ICommandLinker>();

        private static readonly ICommandInvoker DefaultCommandInvoker = new DefaultCommandInvoker();

        private static readonly IEnumerable<IResultProcessor> DefaultResultProcessors = TypeExtensions.LoadAllImplementationsAsReadOnlyList<IResultProcessor>();
        #endregion

        #region Init
        public OptionsModelBuilder(string? token, HttpClient? httpClient, IWebProxy? proxy)
		{
            Token = new OptionsModelValueBuilder<string?>(this, token);
            HttpClient = new OptionsModelValueBuilder<HttpClient?>(this, httpClient);
            Proxy = new OptionsModelValueBuilder<IWebProxy?>(this, proxy);

            CancellationCheckInterval = new OptionsModelValueBuilder<TimeSpan?>(this);
            StateFactory = new OptionsModelFactoryBuilder<IState>(this);
            CommandExtractor = new OptionsModelValueBuilder<ICommandExtractor?>(this);
            AllowedUpdates = new OptionsModelCollectionBuilder<UpdateType>(this);
            Parsers = new OptionsModelCollectionBuilder<ICommandParser>(this);
            Converters = new OptionsModelCollectionBuilder<IConverter>(this);
            DefaultValueProviders = new OptionsModelCollectionBuilder<IDefaultValueProvider>(this);
            SpecialValueProviders = new OptionsModelCollectionBuilder<ISpecialValueProvider>(this);
            Linkers = new OptionsModelCollectionBuilder<ICommandLinker>(this);
            CommandInvoker = new OptionsModelValueBuilder<ICommandInvoker?>(this);
            ResultProcessors = new OptionsModelCollectionBuilder<IResultProcessor>(this);
		}
        #endregion

        #region Functions
        public virtual OptionsModel Build() => new OptionsModel
        (
            Token.Build(),
            CancellationCheckInterval.Build(),
            HttpClient.Build(),
            Proxy.Build(),
            StateFactory.Build(),
            CommandExtractor.Build(),
            AllowedUpdates.Build(),
            Parsers.Build(),
            Converters.Build(),
            DefaultValueProviders.Build(),
            SpecialValueProviders.Build(),
            Linkers.Build(),
            CommandInvoker.Build(),
            ResultProcessors.Build()
        );

        public virtual OptionsModelBuilder SetDefaults()
        {
            SetDefaultCancellationCheckInterval();
            SetDefaultStateFactory();
            SetDefaultCommandExtractor();
            SetDefaultAllowedUpdates();
            SetDefaultParsers();
            SetDefaultConverters();
            SetDefaultDefaultValueProviders();
            SetDefaultSpecialValueProviders();
            SetDefaultLinkers();
            SetDefaultCommandInvoker();
            SetDefaultResultProcessors();

            return this;
        }

        public virtual OptionsModelBuilder SetDefaultCancellationCheckInterval()
        {
            CancellationCheckInterval.Set(DefaultCancellationCheckInterval);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultStateFactory()
        {
            StateFactory.Set(DefaultStateFactory);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultCommandExtractor()
        {
            CommandExtractor.Set(DefaultCommandExtractor);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultAllowedUpdates()
        {
            AllowedUpdates.Set(DefaultAllowedUpdates);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultParsers()
        {
            Parsers.Set(DefaultParsers);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultConverters()
        {
            Converters.Set(DefaultConverters);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultDefaultValueProviders()
        {
            DefaultValueProviders.Set(DefaultDefaultValueProviders);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultSpecialValueProviders()
        {
            SpecialValueProviders.Set(DefaultSpecialValueProviders);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultLinkers()
        {
            Linkers.Set(DefaultLinkers);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultCommandInvoker()
        {
            CommandInvoker.Set(DefaultCommandInvoker);
            return this;
        }

        public virtual OptionsModelBuilder SetDefaultResultProcessors()
        {
            ResultProcessors.Set(DefaultResultProcessors);
            return this;
        }
        #endregion
    }
}
