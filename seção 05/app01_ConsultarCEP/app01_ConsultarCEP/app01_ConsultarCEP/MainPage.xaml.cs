using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using app01_ConsultarCEP.Servico.Modelo;
using app01_ConsultarCEP.Servico;

namespace app01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BtnConsultar.Clicked += BuscarCEP;
        }

        private bool isValidoCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                // Erro
                DisplayAlert("Erro", "CEP Inválido. Deve conter 8 caracteres", "OK");
                valido = false;
            }
            int NovoCEP = 0;

            if(!int.TryParse(cep,out NovoCEP))
            {
                // Erro    
                DisplayAlert("Erro", "CEP Inválido. CEP deve ser composto apenas por números", "OK");
                valido = false;
            }

            return valido;

        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Validações
            string cep = TxtCep.Text.Trim();

            if (isValidoCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cep);

                    TxtResultado.Text = string.Format("Endereço: {2} de {1},{0} ", end.localidade, end.logradouro, end.uf);
                }
                catch (Exception ex)
                {
                    DisplayAlert(ex.Source, ex.Message, "OK");
                }
            }
        }

    }
}
