using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using App3_JTWAsync.Model;

namespace App3_JTWAsync.Services
{
    public class JWTServices
    {
        private static string BaseURL = "http://ws.spacedu.com.br/xf2018/rest/apix";
        private static string token;
        private static string tokenType;
        public async static Task<string> GetToken(string nome, string password)
        {
            var URL = BaseURL + "/token";
            HttpClient requisicao = new HttpClient();

            var parametros = new FormUrlEncodedContent(new[] { new KeyValuePair<string,string>("nome",nome),
                 new KeyValuePair<string,string>("password",password)
                });

            var resposta = await requisicao.PostAsync(URL, parametros);

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                var respostaToken = JsonConvert.DeserializeObject<RepostaToken>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                token = respostaToken.Access_token;
                tokenType = respostaToken.Token_type;
                return token;
            }
            else
            {
                return resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
        public async static Task<string> Verificar()
        {
            var URL = BaseURL + "/verify";
            HttpClient requisicao = new HttpClient();

            requisicao.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType,token);

            var resposta = await requisicao.GetAsync(URL);

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                var respostaToken = JsonConvert.DeserializeObject<RespostaVerificar>(resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                return respostaToken.Usuario.Nome + " " + respostaToken.Usuario.Id.ToString();
            }
            else
            {
                return resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}
