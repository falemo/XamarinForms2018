using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1_Cell.Modelo;
using App1_Cell.Paginas;

namespace App1_Cell.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Cargo = "Gerente TI", Nome = "Pedro" });
            Lista.Add(new Funcionario() { Cargo = "Analista TI", Nome = "Joaquim" });
            Lista.Add(new Funcionario() { Cargo = "Programador TI", Nome = "Tereza" });
            Lista.Add(new Funcionario() { Cargo = "Dono TI", Nome = "Elaine" });
            Lista.Add(new Funcionario() { Cargo = "Presidente TI", Nome = "Guilherme" });
            Lista.Add(new Funcionario() { Cargo = "Entregador TI", Nome = "Madre" });

            ListaFuncionario.ItemsSource = Lista;
        }

        private void ActionSelectListView (object sender, SelectedItemChangedEventArgs args)
        {
            Funcionario func = ((Funcionario)args.SelectedItem);
            Navigation.PushAsync(new Detalhe.DetailPage(func));

        }
        private void FeriasAction(object sender, SelectedItemChangedEventArgs args)
        {
            MenuItem botao = (MenuItem)sender;
            Funcionario func = ((Funcionario)(botao.CommandParameter));
            DisplayAlert("Titulo: " + func.Nome, "Mensagem: " + func.Nome + " - " + func.Cargo, "OK");
        }
        private void AbonoAction(object sender, SelectedItemChangedEventArgs args)
        {
            MenuItem botao = (MenuItem)sender;
            Funcionario func = (Funcionario)botao.CommandParameter;
            DisplayAlert("Titulo: " + func.Nome, "Mensagem: " + func.Nome + " - " + func.Cargo, "OK");
        }
        private void AvisoAction(object sender, SelectedItemChangedEventArgs args)
        {
            MenuItem botao = (MenuItem)sender;
            Funcionario func = (Funcionario)botao.CommandParameter;
            DisplayAlert("Titulo: " + func.Nome, "Mensagem: " + func.Nome + " - " + func.Cargo, "OK");
        }



    }
}