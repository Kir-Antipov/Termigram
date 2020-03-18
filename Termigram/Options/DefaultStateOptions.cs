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
        public DefaultStateOptions(string token) : this(token, default, default) { }

        public DefaultStateOptions(string token, HttpClient httpClient) : this(token, httpClient, default) { }

        public DefaultStateOptions(string token, IWebProxy proxy) : this(token, default, proxy) { }

        protected DefaultStateOptions(string token, HttpClient? httpClient, IWebProxy? proxy) : base(token, httpClient, proxy)
        {
            StateFactory = () => new DefaultState();
        }
        #endregion
    }
}
