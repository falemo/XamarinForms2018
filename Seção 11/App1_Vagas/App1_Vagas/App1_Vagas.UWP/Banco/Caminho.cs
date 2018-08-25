using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_Vagas.Banco;
using System.IO;
using App1_Vagas.UWP.Banco;
using Windows.Storage;

[assembly: Dependency(typeof(Caminho))]

namespace App1_Vagas.UWP.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBancodeDados)
        {
            string caminhodaPasta = ApplicationData.Current.LocalFolder.Path;
            string caminhoBanco = Path.Combine(caminhodaPasta, NomeArquivoBancodeDados);

            return caminhoBanco;
        }
    }
}
