//using Microsoft.JSInterop;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//namespace SmartBurguerValueRCL.Services
//{
//    public class CustomAuthorizationMessageHandler : DelegatingHandler
//    {
//        private readonly CustomAuthStateProvider _auth;

//        public CustomAuthorizationMessageHandler(CustomAuthStateProvider auth)
//        {
//            _auth = auth;
//        }

//        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            var token = await _auth.GetToken(); // método que lê do localStorage

//            if (!string.IsNullOrWhiteSpace(token))
//            {
//                Console.WriteLine($"[DEBUG] Adicionando Bearer {token.Substring(0, 20)}... ao request {request.RequestUri}");
//                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
//            }
//            else
//            {
//                Console.WriteLine($"[DEBUG] Nenhum token encontrado para {request.RequestUri}");
//            }

//            return await base.SendAsync(request, cancellationToken);
//        }
//    }
//}
using System.Net.Http.Headers;

namespace SmartBurguerValueRCL.Services
{
    public class CustomAuthorizationMessageHandler : DelegatingHandler
    {
        private readonly CustomAuthStateProvider _auth;

        public CustomAuthorizationMessageHandler(CustomAuthStateProvider auth)
        {
            _auth = auth;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _auth.GetToken(); // Busca token do localStorage ou outro local

            Console.WriteLine($"[DEBUG] Request para: {request.RequestUri}");
            Console.WriteLine($"[DEBUG] Token: {(string.IsNullOrWhiteSpace(token) ? "NULL" : token.Substring(0, 20) + "...")}");

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
