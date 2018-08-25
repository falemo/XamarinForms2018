using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_Vagas.Modelos;
using App1_Vagas.Banco;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MinhasVagasCadastradas : ContentPage
	{
        List<Vaga> ListVagasLocal { get; set; }
        public MinhasVagasCadastradas ()
		{
			InitializeComponent ();
            AtualizarEstrutura();



        }
        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaVagas.ItemsSource = ListVagasLocal.Where(a => a.Cargo.Contains(args.NewTextValue)).ToList();

            lblQuantidadeRegistros.Text = ListVagasLocal.Count.ToString() + " vagas cadastras atualmente.";
        }
        public void EditarAction (object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            Vaga vaga = (Vaga)((TapGestureRecognizer)(lblEditar.GestureRecognizers[0])).CommandParameter;
            Navigation.PushAsync(new EditarVagas(vaga));
        }
        private void AtualizarEstrutura()
        {
            ListVagasLocal = new AcessoBanco().Consultar();
            ListaVagas.ItemsSource = ListVagasLocal;

            lblQuantidadeRegistros.Text = ListVagasLocal.Count.ToString() + " vagas cadastras atualmente.";
        }
        public void ExcluirAction(object sender, EventArgs args)
        {
            Label lblExcluir = (Label)sender;
            Vaga vaga = (Vaga)((TapGestureRecognizer)(lblExcluir.GestureRecognizers[0])).CommandParameter;

            new AcessoBanco().Exclusao(vaga);

            AtualizarEstrutura();

        }

    }
}