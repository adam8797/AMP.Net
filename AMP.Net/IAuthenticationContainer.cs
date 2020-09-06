using System;
using System.Collections.Generic;
using System.Text;
using AMP.Net.Models;

namespace AMP.Net
{
    public interface IAuthenticationContainer
    {
        public string? SessionId { get; }

        public bool IsAuthenticated { get; }
    }

    public class DefaultAuthenticationContainer : IAuthenticationContainer
    {
        private readonly LoginResponse? _response;

        public DefaultAuthenticationContainer(LoginResponse response)
        {
            _response = response;
        }

        public DefaultAuthenticationContainer()
        {
            _response = null;
        }

        public string? SessionId => _response?.SessionId.ToString("D");

        public bool IsAuthenticated => _response != null;
    }
}
