using Lab.Celton.Core.Options.Options;
using Lab.Celton.Core.Options.Services.Contract;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Celton.Core.Options.Services
{
    public class MyTestService : IMyTestService
    {
        private string argumentNullExceptionDefaultMessage = "Parameter Required";

        private readonly IOptions<AccessOptions> _accessConfiguration;
        private readonly IOptions<AuthenticateOptions> _authenticateConfiguration;

        public MyTestService(IOptions<AccessOptions> accessConfiguration, IOptions<AuthenticateOptions> authenticateConfiguration)
        {
            _accessConfiguration = accessConfiguration ?? throw new ArgumentNullException("AccessOptions", argumentNullExceptionDefaultMessage);
            _authenticateConfiguration = authenticateConfiguration ?? throw new ArgumentNullException("AuthenticateOptions", argumentNullExceptionDefaultMessage);
        }

        public string GetAccessPoint()
        {
            string host = _accessConfiguration?.Value?.Host ?? throw new ArgumentNullException("AccessOptions.Host", argumentNullExceptionDefaultMessage);
            string port = _accessConfiguration?.Value?.Port.ToString() ?? throw new ArgumentNullException("AccessOptions.Port", argumentNullExceptionDefaultMessage);
            string accessToken = _accessConfiguration?.Value?.AccessToken ?? throw new ArgumentNullException("AccessOptions.AccessToken", argumentNullExceptionDefaultMessage);

            return $"{host}:{port}?token={accessToken}";
        }

        public string GetCredencial()
        {
            string user = _authenticateConfiguration?.Value?.User ?? throw new ArgumentNullException("AuthenticateOptions.User", argumentNullExceptionDefaultMessage);
            string password = _authenticateConfiguration?.Value?.Password ?? throw new ArgumentNullException("AuthenticateOptions.Password", argumentNullExceptionDefaultMessage);

            return $"User: {user} // Password:{password}";
        }
    }
}
