using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AMP.Net.Models;

namespace AMP.Net
{
    public class AmpClientCollection
    {
        private AmpClient _rootClient;

        public AmpClientCollection(string url)
        {
            _rootClient = new AmpClient(url);
            Core = new CoreAmpClient(_rootClient);
            ADSModule = new AdsModuleAmpClient(_rootClient);
        }

        public CoreAmpClient Core { get; }

        public AdsModuleAmpClient ADSModule { get; set; }
    }

    public class AmpClient
    {
        private readonly AmpClient? _parent;

        private readonly HttpClient _client;
        protected HttpClient Client => _parent?.Client ?? _client;

        private IAuthenticationContainer _auth;
        protected IAuthenticationContainer Auth
        {
            get => _parent?.Auth ?? _auth;
            set
            {
                if (_parent == null)
                    _auth = value;
                else
                    _parent.Auth = value;
            }
        }

        public AmpClient(string url)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AMP.Net", Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "N/A"));
            _auth = new DefaultAuthenticationContainer();
        }

        protected AmpClient(AmpClient baseClient)
        {
            _parent = baseClient;
        }

        protected async Task<TResponse> MakeRequestAsync<TResponse>(string path, [NotNull]object request, CancellationToken token = default) where TResponse: class
        {
            var rawResponse = await Client.PostAsync(path, new JsonContent(request), token);

            var body = await rawResponse.Content.ReadAsStringAsync();

            var parsedResponse = JsonSerializer.Deserialize<TResponse>(body);

            return parsedResponse;
        }

        protected async Task<TResponse> MakeSessionRequestAsync<TResponse>(string path, [NotNull] AuthenticatedRequest request,
            CancellationToken token = default) where TResponse : class
        {
            if (!Auth.IsAuthenticated || Auth.SessionId == null)
                throw new Exception("You must login first");

            request.SessionId = Auth.SessionId;

            return await MakeRequestAsync<TResponse>(path, request, token);
        }
    }
}
