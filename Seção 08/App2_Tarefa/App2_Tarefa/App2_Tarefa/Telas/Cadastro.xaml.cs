using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_Tarefa.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        private byte Prioridade { get; set; }
		public Cadastro ()
		{
			InitializeComponent ();
		}
        public void PrioridadeSelectAction(object sender, EventArgs args)
        {
            var stacks = SLPrioridades.Children;

            foreach (var Linha in stacks)
            {
                Label lblPrioridade = ((StackLayout)Linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }
            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;

            FileImageSource source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;

            this.Prioridade = byte.Parse(source.File.ToString().Replace("Resources/B", "").Replace(".png", ""));

        }
        public void SalvarAction(object sender, EventArgs args)
        {
            bool errorexiste = false;
            if (!(txtNome.Text.Trim().Length > 0))
            {
                errorexiste = true;
                DisplayAlert("Erro", "Nome não preenchido", "OK");
            }
            if (!(this.Prioridade> 0))
            {
                errorexiste = true;
                DisplayAlert("Erro", "Prioridade não selecionada", "OK");

            }

            if (errorexiste == false)
            {
                //salva dados.
                App2_Tarefa.Modelos.Tarefa tarefa = new Modelos.Tarefa();
                tarefa.Nome = txtNome.Text.Trim();
                tarefa.Prioridade = this.Prioridade;
                new App2_Tarefa.Modelos.GerenciadorTarefas().Salvar(tarefa);

                //txtNome.Text = new App2_Tarefa.Modelos.GerenciadorTarefas().Listar().Count.ToString();

                App.Current.MainPage = new NavigationPage(new Inicio());

            }
        }
        

    }
}