using System;
using System.Threading;
using System.Threading.Tasks;
using AMP.Net.Models;

namespace AMP.Net
{
    public class CoreAmpClient : AmpClient
    {
        private readonly Guid? _serverId;

        public CoreAmpClient(AmpClient baseClient) : base(baseClient)
        {
            _serverId = null;
        }

        public CoreAmpClient(Guid serverId, AmpClient baseClient) : base(baseClient)
        {
            _serverId = serverId;
        }

        private string BuildPath(string path)
        {
            if (_serverId.HasValue)
                return $"/API/ADSModule/Servers/{_serverId:D}/{path.TrimStart('/')}";
            return path;
        }

        public async Task<LoginResponse> LoginAsync(string username, string password, bool saveLogin = true, CancellationToken token = default)
        {
            var request = new LoginRequest()
            {
                Username = username,
                Password = password,
                RememberMe = false,
                Token = ""
            };

            var resp = await MakeRequestAsync<LoginResponse>(BuildPath("/API/Core/Login"), request, token);

            if (resp.Success && saveLogin)
                Auth = new DefaultAuthenticationContainer(resp);

            return resp;
        }
    }
}