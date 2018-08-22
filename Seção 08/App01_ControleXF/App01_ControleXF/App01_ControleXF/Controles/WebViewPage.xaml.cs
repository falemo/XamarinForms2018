using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebViewPage : ContentPage
	{
		public WebViewPage ()
		{
			InitializeComponent ();
		}
        private void GOPagina (object sender, EventArgs args)
        {
            Navegador.Source = EnderecoSite.Text;
        }
        private void GOProximo(object sender, EventArgs args)
        {
            if (Navegador.CanGoForward)
            {
                Navegador.GoForward();
            }
        }

        private void GOVoltar(object sender, EventArgs args)
        {
            if (Navegador.CanGoBack)
            {
                Navegador.GoBack();
            }

        }
        private void ActionCarregando(object sender, EventArgs args)
        {
            LblStatus.Text = "Carregando...";

        }
        private void ActionCarregado(object sender, EventArgs args)
        {
            LblStatus.Text = "Carregado...";
            

        }


    }
}