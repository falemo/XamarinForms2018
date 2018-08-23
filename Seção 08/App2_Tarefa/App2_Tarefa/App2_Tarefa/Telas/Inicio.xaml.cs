using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App2_Tarefa.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_Tarefa.Telas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();
            DataHoje.Text = DateTime.Now.DayOfWeek.ToString() +", " + DateTime.Now.ToString("dd/MM");
            CarregarTarefas();

        }
        public void ActionGOCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());

        }
        public void CarregarTarefas()
        {
            SLTarefas.Children.Clear();
            List<Tarefa> Lista = new GerenciadorTarefas().Listar();
            int index = 0;
            foreach (Tarefa tarefa in Lista)
            {
                LinhaStacklayout(tarefa,index);
                index++;
            }
        }
        public void LinhaStacklayout (Tarefa tarefa, int index)
        {
            Image Delete = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                Delete.Source = ImageSource.FromFile("Resources/Delete.png");
            }

            Image Prioridade = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("B"+tarefa.Prioridade.ToString()+".png") };
            if (Device.RuntimePlatform == Device.UWP)
            {
                Prioridade.Source = ImageSource.FromFile("Resources/B" + tarefa.Prioridade.ToString() +".png");
            }

            TapGestureRecognizer DeleteTep = new TapGestureRecognizer();
            DeleteTep.Tapped += delegate
            {
                new GerenciadorTarefas().Remover(index);
                CarregarTarefas();
            };
            Delete.GestureRecognizers.Add(DeleteTep);

            View stackCentral = null;
            if (tarefa.Datafinalizado == null)
            {
                stackCentral = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand, Text = tarefa.Nome };
            }
            else
            {
                stackCentral = new StackLayout { VerticalOptions = LayoutOptions.Center, Spacing = 0, HorizontalOptions = LayoutOptions.FillAndExpand };
                ((StackLayout)stackCentral).Children.Add(new Label() {Text = tarefa.Nome,TextColor = Color.Gray });
                ((StackLayout)stackCentral).Children.Add(new Label() { FontSize=10, Text = "Finalizado em " + tarefa.Datafinalizado.Value.ToString("dd/MM/yyyy - hh:MM:ss") + "h", TextColor = Color.Gray });
            }


            Image check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("CheckOff.png")};
            if (Device.RuntimePlatform == Device.UWP)
            {
                check.Source = ImageSource.FromFile("Resources/CheckOff.png");
            }

            if (tarefa.Datafinalizado != null)
            {
                check.Source = ImageSource.FromFile("CheckON.png");
                if (Device.RuntimePlatform == Device.UWP)
                {
                    check.Source = ImageSource.FromFile("Resources/CheckON.png");
                }
            }

                TapGestureRecognizer CheckTep = new TapGestureRecognizer();
            CheckTep.Tapped += delegate
            {
                new GerenciadorTarefas().Finalizar(index, tarefa);
                CarregarTarefas();
            };
            check.GestureRecognizers.Add(CheckTep);


            StackLayout Linha = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 15 };

            Linha.Children.Add(check);
            Linha.Children.Add(stackCentral);
            Linha.Children.Add(Prioridade);
            Linha.Children.Add(Delete);

            SLTarefas.Children.Add(Linha);
          }
    }
}