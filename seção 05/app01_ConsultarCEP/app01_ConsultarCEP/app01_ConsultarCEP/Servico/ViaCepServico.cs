using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using app01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace app01_ConsultarCEP.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {

            try
            {
                string novoenderecoURL = string.Format(EnderecoURL, cep);
                WebClient wc = new WebClient();
                string conteudo = wc.DownloadString(novoenderecoURL);

                Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

                if (end.cep == null) throw new Exception("CEP Inexistente! ou Falha na consulta externa.");

                return end;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
           
        }

    }
}
