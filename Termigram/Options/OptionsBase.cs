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
    public abstract class OptionsBase : IOptions
    {
        #region Var
        public abstract string Token { get; }
        public abstract TimeSpan CancellationCheckInterval { get; }
        public abstract HttpClient? HttpClient { get; }
        public abstract IWebProxy? Proxy { get; }
        public abstract ICommandExtractor CommandExtractor { get; }
        public abstract IReadOnlyList<UpdateType>? AllowedUpdates { get; }
        public abstract IReadOnlyList<ICommandParser> Parsers { get; }
        public abstract IReadOnlyList<IConverter>? Converters { get; }
        public abstract IReadOnlyList<IDefaultValueProvider>? DefaultValueProviders { get; }
        public abstract IReadOnlyList<ISpecialValueProvider>? SpecialValueProviders { get; }
        public abstract IReadOnlyList<ICommandLinker> Linkers { get; }
        public abstract ICommandInvoker CommandInvoker { get; }
        public abstract IReadOnlyList<IResultProcessor> ResultProcessors { get; }
        #endregion

        #region Functions
        public override string ToString() => Token;
        public override int GetHashCode() => Token.GetHashCode();
        public override bool Equals(object? obj) => obj is IOptions options && Token == options.Token;
        #endregion
    }
}
