using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using App1_NossoChat.Model;
using App1_NossoChat.Services;
using System.Linq;
using App1_NossoChat.Util;

namespace App1_NossoChat.ViewModel
{
    public class MensagemViewModel: INotifyPropertyChanged
    {

        public Command BtnEnviarMensagem { get; set; }
        public Command AtualizaMensagem { get; set; }

        private StackLayout SL;
        private Chat chat;

        private List<Mensagem> _Mensagens;

        public List<Mensagem> Mensagens
        {
            get { return _Mensagens; }
            set
            {
                _Mensagens = value;
                OnPropertyChange("Mensagens");
                ShowOnScreen();
            }
        }

        private string _TxtMensagem;

        public string TxtMensagem
        {
            get { return _TxtMensagem; }
            set
            {
                _TxtMensagem = value;
                OnPropertyChange("TxtMensagem");
            }
        }

        private void OnPropertyChange(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }

        }

        private void ShowOnScreen()
        {
            var usuario = UsuarioUtil.GetUsuarioLogado();
            SL.Children.Clear();
            if (Mensagens != null)
            {
                foreach (var msg in Mensagens)
                {
                    if (msg.Usuario.Id == usuario.Id)
                    {
                        SL.Children.Add(CriarMensagemPropria(msg));
                    }
                    else
                    {
                        SL.Children.Add(CriarMensagemOutroUsuario(msg));
                    }
                }
            }
            else
            {
                SL.Children.Add(CriarMensagemAviso("Não há mensagem para este Chat!"));
            }
        }

        private Xamarin.Forms.View CriarMensagemPropria(Mensagem mensagem)
        {
            var layout = new StackLayout() { Padding = 5, BackgroundColor = Color.FromHex("#5ED055"), HorizontalOptions = LayoutOptions.End };
            var label = new Label() { TextColor = Color.White, FontSize =10, Text = mensagem.mensagem };

            layout.Children.Add(label);

            //< StackLayout Padding = "5" BackgroundColor = "#5ED055" HorizontalOptions = "End" >
            //< Label  Text = "Olá amigos tudo bom?" TextColor = "White" ></ Label >
            //</ StackLayout >

            return layout;
                          
        }
        private Xamarin.Forms.View CriarMensagemAviso(string mensagem)
        {
            var LabelNome = new Label() { Text = "AVISO", FontSize = 10, TextColor = Color.FromHex("#5ED055") };
            var LabelMensagem = new Label() { Text = mensagem, FontSize = 10, TextColor = Color.FromHex("#5ED055") }; ;
            var SL = new StackLayout();
            SL.Children.Add(LabelNome);
            SL.Children.Add(LabelMensagem);

            var frame = new Frame() { BorderColor = Color.FromHex("#5ED055"), CornerRadius = 0, HorizontalOptions = LayoutOptions.Start };
            frame.Content = SL;

            //< Frame OutlineColor = "#5ED055" CornerRadius = "0" HorizontalOptions = "Start" >
            //< StackLayout >
            //< Label Text = "Felipe123" FontSize = "10" TextColor = "#5ED055" ></ Label >
            //< Label Text = "olá Amigos" FontSize = "10" TextColor = "#5ED055" ></ Label >
            //</ StackLayout >
            //</ Frame >
            return frame;
        }

        private Xamarin.Forms.View CriarMensagemOutroUsuario(Mensagem mensagem)
        {
            var LabelNome = new Label() { Text = mensagem.Usuario.Nome, FontSize = 10, TextColor = Color.FromHex("#5ED055") };
            var LabelMensagem = new Label() { Text = mensagem.mensagem, FontSize = 10, TextColor = Color.FromHex("#5ED055") }; ;
            var SL = new StackLayout();
            SL.Children.Add(LabelNome);
            SL.Children.Add(LabelMensagem);
           
            var frame = new Frame() { BorderColor = Color.FromHex("#5ED055"), CornerRadius = 0, HorizontalOptions = LayoutOptions.Start };
            frame.Content = SL;

            //< Frame OutlineColor = "#5ED055" CornerRadius = "0" HorizontalOptions = "Start" >
            //< StackLayout >
            //< Label Text = "Felipe123" FontSize = "10" TextColor = "#5ED055" ></ Label >
            //< Label Text = "olá Amigos" FontSize = "10" TextColor = "#5ED055" ></ Label >
            //</ StackLayout >
            //</ Frame >
            return frame;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MensagemViewModel(Chat chat, StackLayout SLMensagemContainer)
        {
            this.chat = chat;
            SL = SLMensagemContainer;
            AtualizarMensagem(); // Mensagens = ServicoChat.GetMensagensChat(chat);
            BtnEnviarMensagem = new Command(EnviarMensagem);
            AtualizaMensagem = new Command(AtualizarMensagem);

            Device.StartTimer(TimeSpan.FromSeconds(2), () => {
                AtualizarMensagem();
                return true;
            });

        }

        private void AtualizarMensagem()
        {
            Mensagens = ServicoChat.GetMensagensChat(chat);

        }

        private void EnviarMensagem()
        {
            var msg = new Mensagem()
            {
                Idusuario = UsuarioUtil.GetUsuarioLogado().Id,
                mensagem = TxtMensagem,
                IdChat = chat.Id
            };

            ServicoChat.InsertMensagem(msg);
            AtualizarMensagem();

            TxtMensagem = string.Empty;

        }
    }
}
