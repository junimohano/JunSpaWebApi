using System;
using System.Net;

namespace JunSpaWebApi.Backup
{
    public class JunProxy : IWebProxy
    {
        public JunProxy(string proxyUri) : this(new Uri(proxyUri))
        {
        }
        public JunProxy(Uri proxyUri)
        {
            this.ProxyUri = proxyUri;
        }

        public Uri ProxyUri { get; set; }

        public ICredentials Credentials { get; set; }

        public Uri GetProxy(Uri destination)
        {
            return this.ProxyUri;
        }

        public bool IsBypassed(Uri host)
        {
            return false; /* Proxy all requests */
        }
    }
}
