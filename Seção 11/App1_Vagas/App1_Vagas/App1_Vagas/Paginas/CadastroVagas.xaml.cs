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
	public partial class CadastroVagas : ContentPage
	{
        public CadastroVagas()
        {
            InitializeComponent();
        }
        public CadastroVagas(Vaga vaga)
		{
			InitializeComponent ();

            if (vaga != null)
            {
                //Edicao
            }

		}
        public void SalvarAction(object sender, EventArgs args)
        {
            //TODO - Validar Dados do Cadastro.
            Vaga vaga = new Vaga();
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

            new AcessoBanco().Cadastro(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultaVagas());

            Navigation.PopAsync();
        }

    }
}