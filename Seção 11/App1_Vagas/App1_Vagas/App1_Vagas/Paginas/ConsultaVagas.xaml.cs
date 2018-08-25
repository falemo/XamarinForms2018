using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Vagas.Modelos;
using App1_Vagas.Banco;

namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaVagas : ContentPage
	{
        List<Vaga> ListVagasLocal { get; set; }
		public ConsultaVagas ()
		{
			InitializeComponent ();

            ListVagasLocal = new AcessoBanco().Consultar();
            ListaVagas.ItemsSource = ListVagasLocal;

            lblQuantidadeRegistros.Text = ListVagasLocal.Count.ToString() + " vagas cadastras atualmente.";
		}
        public void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastroVagas());
        }
        public void GoPMinhasVagas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }
        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaVagas.ItemsSource = ListVagasLocal.Where(a => a.Cargo.Contains(args.NewTextValue)).ToList();

            lblQuantidadeRegistros.Text = ListVagasLocal.Count.ToString() + " vagas cadastras atualmente.";
        }
        public void MaisDetalhesAction(object sender, EventArgs args)
        {
            Label lblDetalhe = (Label)sender;
            Vaga vaga = (Vaga)((TapGestureRecognizer)(lblDetalhe.GestureRecognizers[0])).CommandParameter;
            Navigation.PushAsync(new DetalheVaga(vaga));

        }

        

    }
}