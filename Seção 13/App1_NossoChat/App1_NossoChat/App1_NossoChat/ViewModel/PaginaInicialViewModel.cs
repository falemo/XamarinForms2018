using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using Newtonsoft.Json;
using App1_NossoChat.Model;
using App1_NossoChat.Services;

namespace App1_NossoChat.ViewModel
{
    class PaginaInicialViewModel : INotifyPropertyChanged
    {
        private string _nome;
        private string _senha;
        private string _mensagem;

        public string Nome { get { return _nome; } set { _nome = value; PropertyChanged(this, new PropertyChangedEventArgs("Nome")); } }
        public string Senha { get { return _senha; } set { _senha = value; PropertyChanged(this, new PropertyChangedEventArgs("Senha")); } }
        public string Mensagem { get { return _mensagem; } set { _mensagem = value; PropertyChanged(this, new PropertyChangedEventArgs("Mensagem")); } }
        public Command AcessarCommand { get; set; }

        public PaginaInicialViewModel()
        {
            AcessarCommand = new Command(Acessar);

        }

        private void Acessar()
        {
            Usuario user = new Usuario();
            user.Nome = Nome;
            user.Password = Senha;

            var usuariologado = ServicoChat.GetUsuario(user);

            if (usuariologado == null)
            {
                Mensagem = "Ocorreu erro ao tentar logar o usuário. Usuário ou senha podem não conferir!";
            }
            else
            {
                Util.UsuarioUtil.SetUsuarioLogado(usuariologado);
                //App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(usuariologado);
                App.Current.MainPage = new NavigationPage(new View.Chats()) { BarBackgroundColor = Color.FromHex("#5ED055"), BarTextColor = Color.White };
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
