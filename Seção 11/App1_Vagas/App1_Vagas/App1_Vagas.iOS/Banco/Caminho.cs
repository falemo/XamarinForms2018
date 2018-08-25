using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using App1_Vagas.Banco;
using System.IO;
using App1_Vagas.iOS.Banco;

[assembly: Dependency(typeof(Caminho))]

namespace App1_Vagas.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBancodeDados)
        {
            string caminhodaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoBiblioteca = Path.Combine(caminhodaPasta, "..", "Library");
            string caminhoBanco = Path.Combine(caminhoBiblioteca, NomeArquivoBancodeDados);

            return caminhoBanco;

        }
    }
}