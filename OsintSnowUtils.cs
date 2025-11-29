using System.Net;
using System.Net.Sockets;

namespace OsintSnowSharp
{
    internal class OsintSnowUtils
    {
        public static HttpClient CreateHttpClient(string osintSnowApiKey)
        {
            SocketsHttpHandler handler = new SocketsHttpHandler
            {
                ConnectCallback = async (ctx, ct) =>
                {
                    Socket socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp)
                    {
                        NoDelay = true,
                        DualMode = true,
                    };

                    await socket.ConnectAsync(ctx.DnsEndPoint, ct).ConfigureAwait(false);
                    return new NetworkStream(socket, ownsSocket: true);
                },

                UseProxy = false,
                Proxy = null,
                UseCookies = false,
                AllowAutoRedirect = false,
                AutomaticDecompression = DecompressionMethods.None,

                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(10),
                PooledConnectionLifetime = Timeout.InfiniteTimeSpan,
                MaxConnectionsPerServer = int.MaxValue,

                EnableMultipleHttp2Connections = true
            };

            HttpClient client = new HttpClient(handler, disposeHandler: true)
            {
                Timeout = TimeSpan.FromSeconds(99999),
                DefaultRequestVersion = HttpVersion.Version30,
                DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher
            };

            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Host", "osintsnow.tools");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Origin", "https://osintsnow.tools");
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:145.0) Gecko/20100101 Firefox/145.0");
            client.DefaultRequestHeaders.TryAddWithoutValidation("X-API-Key", $"{osintSnowApiKey}");

            return client;
        }
    }
}