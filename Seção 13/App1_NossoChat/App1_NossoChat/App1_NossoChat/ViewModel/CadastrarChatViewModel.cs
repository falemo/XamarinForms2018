using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1_NossoChat.Model;
using App1_NossoChat.Services;
using System.ComponentModel;

namespace App1_NossoChat.ViewModel
{
    public class CadastrarChatViewModel: INotifyPropertyChanged
    {
        private string _nome;
        public string nome { get { return _nome; } set { _nome = value; OnPropertyChange("nome"); } }

        private string _mensagem;
        public string mensagem { get { return _mensagem; } set { _mensagem = value; OnPropertyChange("mensagem"); } }

        public Command CadastrarChat { get; set; }


        public CadastrarChatViewModel()
        {
            CadastrarChat = new Command(Cadastrar);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Cadastrar()
        {
            var chat = new Chat() { Nome = nome };
            bool ok = ServicoChat.InsertChat(chat);

            if (ok == true)
            {
                ((NavigationPage)(App.Current.MainPage)).Navigation.PopAsync();
                var Nav = (NavigationPage)App.Current.MainPage;
                var Chats = (View.Chats) Nav.RootPage;
                var viewModel = (ChatsViewModel)Chats.BindingContext;
                if (viewModel.AtualizarChat.CanExecute(null))
                {
                    viewModel.AtualizarChat.Execute(null);
                }
            }
            else
            {
                mensagem = "Ocorreu um erro de cadastro!";
            }
        }

        private void OnPropertyChange(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }

        }

    }
}
