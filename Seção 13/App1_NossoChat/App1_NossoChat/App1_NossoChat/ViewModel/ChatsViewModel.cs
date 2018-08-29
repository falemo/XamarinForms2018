    using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using App1_NossoChat.Model;
using App1_NossoChat.Services;
using System.Linq;

namespace App1_NossoChat.ViewModel
{
    public class ChatsViewModel : INotifyPropertyChanged
    {

        
        private Chat _SelectItemChat;

        public Chat SelectItemChat { get { return _SelectItemChat; }
        set { _SelectItemChat = value;
              OnPropertyChange("SelectItemChat");
                GoPaginaMensagem(value);
            } }

        public Command AdicionarChat { get; set; }
        public Command OrdenarChat { get; set; }
        public Command AtualizarChat { get; set; }


        private List<Chat> _Chats;

        public List<Chat> Chats { get { return _Chats; } set { _Chats = value; OnPropertyChange("Chats"); }}

        public ChatsViewModel()
        {
            Chats = ServicoChat.GetChats();

            AdicionarChat = new Command(Adicionar);
            OrdenarChat = new Command(Ordenar);
            AtualizarChat = new Command(Atualizar);
        }

        private void GoPaginaMensagem(Chat chat)
        {
            if (chat != null)
            {
                SelectItemChat = null;
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat));
            }
        }

        private void Adicionar()
        {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }
        private void Ordenar()
        {
            Chats = Chats.OrderBy (a => a.Nome).ToList();   
        }
        private void Atualizar()
        {
            Chats = ServicoChat.GetChats();
        }


        private void OnPropertyChange(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
