using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App2_ListaBrasil.Modelo;
using Newtonsoft.Json;

namespace App2_ListaBrasil.Servico
{
    public class EstadoServico
    {
        private static string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
        private static string urlMunicipio = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";

        public static List<Estado> GetEstado()
        {
            WebClient ws = new WebClient();
            string conteudo = ws.DownloadString(url);
            return JsonConvert.DeserializeObject<List<Estado>>(conteudo);

        }

        public static List<Municipio> GetMunicipio(int idestado)
        {
            string newURL = string.Format(urlMunicipio, idestado);
            WebClient ws = new WebClient();
            string conteudo = ws.DownloadString(newURL);
            return JsonConvert.DeserializeObject<List<Municipio>>(conteudo);

        }

    }
}
