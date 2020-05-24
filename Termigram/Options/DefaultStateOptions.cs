using System;
using System.Net;
using System.Net.Http;
using Termigram.State;

namespace Termigram.Options
{
    public class DefaultStateOptions : DefaultOptions, IStateOptions
    {
        #region Var
        public Func<IState> StateFactory { get; }
        #endregion

        #region Init
        public DefaultStateOptions(string token) : this(token ?? throw new ArgumentNullException(nameof(token)), default, default) { }

        public DefaultStateOptions(string token, HttpClient httpClient) : this(token ?? throw new ArgumentNullException(nameof(token)), httpClient ?? throw new ArgumentNullException(nameof(httpClient)), default) { }

        public DefaultStateOptions(string token, IWebProxy proxy) : this(token ?? throw new ArgumentNullException(nameof(token)), default, proxy ?? throw new ArgumentNullException(nameof(proxy))) { }

        protected DefaultStateOptions(string token, HttpClient? httpClient, IWebProxy? proxy) : base(token, httpClient, proxy)
        {
            StateFactory = Model.StateFactory ?? throw new ArgumentNullException(nameof(StateFactory));
        }
        #endregion
    }
}
