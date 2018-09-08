using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App3_JTWAsync.Services;
using App3_JTWAsync.Model;
using System.Net;


namespace App3_JTWAsync
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void GetTokenAction(object sender, EventArgs args)
        {
            string resultado = await JWTServices.GetToken(nome.Text, password.Text);
            lblToken.Text = resultado;

        }
        public async void VerificarAction(object sender, EventArgs args)
        {
            string resultado = await JWTServices.Verificar();
            lblResultado.Text = resultado;
        }
    }
}
