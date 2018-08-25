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
	public partial class EditarVagas : ContentPage
	{
        private Vaga vaga { get; set; }

        public EditarVagas (Vaga vaga)
		{
			InitializeComponent ();
            this.vaga = vaga;
            Cargo.Text = vaga.Cargo;
            Empresa.Text = vaga.Empresa;
            Cidade.Text = vaga.Cidade;
            Quantidae.Text = vaga.Quantidade.ToString();
            Cidade.Text = vaga.Cidade;
            Salario.Text = vaga.Salario.ToString();
            DescCargo.Text = vaga.Descricao;
            if (vaga.Tipocontracao == "CLT")
            {
                TipoContratacao.IsToggled = true;

            }else
            {
                TipoContratacao.IsToggled = false;
            }
            Telefone.Text = vaga.Telefone;
            Email.Text = vaga.Email;
        }

        private void SalvarAction(object sender, EventArgs args)
        {
            vaga.Cargo = Cargo.Text;
            vaga.Empresa = Empresa.Text;
            vaga.Cidade = Cidade.Text;
            vaga.Quantidade = short.Parse(Quantidae.Text);
            vaga.Cidade = Cidade.Text;
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Descricao = DescCargo.Text;
            vaga.Tipocontracao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            new AcessoBanco().Atualizacao(vaga);

            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());
        }


    }
}