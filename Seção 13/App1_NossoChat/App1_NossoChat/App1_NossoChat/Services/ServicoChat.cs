using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using App1_NossoChat.Model;
using Newtonsoft.Json;

namespace App1_NossoChat.Services
{
    public class ServicoChat
    {
        private static string EnderecoBase = "http://ws.spacedu.com.br/xf2018/rest/api";
        public static Usuario GetUsuario(Usuario usuario)
        {
            var url = EnderecoBase + "/usuario";

            //Query String: ?q=Footbal&Tipo=imagem
            //StringContent paramentros = new StringContent(string.Format("?nome={0}&Password{1}",usuario.Nome,usuario.Password));
            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] { new KeyValuePair<string,string>("nome",usuario.Nome),
               new KeyValuePair<string,string>("password",usuario.Password) });


            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(url, parametros).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                var conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<Usuario>(conteudo);
            }
            return null;

        }
        public static List<Chat> GetChats()
        {
            var url = EnderecoBase + "/chats";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(url).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                //TODO - Deserealizar e Retornar no metodo e salvar como login.  
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                List<Chat> lista = JsonConvert.DeserializeObject<List<Chat>>(conteudo);
                if (conteudo.Length > 2)
                {
                    return lista;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public static bool InsertChat(Chat chat)
        {
            var url = EnderecoBase + "/chat";

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("nome", chat.Nome) });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(url, parametros).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public static bool RenomearChat(Chat chat)
        {
            var url = EnderecoBase + "/chat/" + chat.Id.ToString();

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("nome", chat.Nome) });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PutAsync(url, parametros).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public static bool DeleteChat(Chat chat)
        {
            var url = EnderecoBase + "/chat/Delete/" + chat.Id.ToString();

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(url).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public static List<Mensagem> GetMensagensChat(Chat chat)
        {
            var url = EnderecoBase + "/chat/" + chat.Id.ToString() + "/msg";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(url).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (conteudo.Length > 2)
                {
                    List<Mensagem> lista = JsonConvert.DeserializeObject <List<Mensagem>>(conteudo);
                    return lista;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static bool InsertMensagem(Mensagem mensagem)
        {
            var url = EnderecoBase + "/chat/" + mensagem.IdChat.ToString() + "/msg";
            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("mensagem", mensagem.mensagem),
            new KeyValuePair<string, string>("id_usuario", mensagem.Idusuario.ToString())});

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(url, parametros).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public static bool DeleteMensagem(Mensagem mensagem)
        {
            var url = EnderecoBase + "/chat/" + mensagem.IdChat.ToString() + "/delete/" + mensagem.Id.ToString();

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.DeleteAsync(url).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

    }
}
