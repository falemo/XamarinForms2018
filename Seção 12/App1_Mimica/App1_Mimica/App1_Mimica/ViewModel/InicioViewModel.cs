using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;
using System.ComponentModel;
using Xamarin.Forms;
using App1_Mimica.Armazenamento;

namespace App1_Mimica.ViewModel
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }

        public string MsgErro { get { return _MsgErro; } set { _MsgErro = value; OnPropertyChanged("MsgErro"); } }

        private string _MsgErro;

        public Command IniciarCommand { get; set; }

        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo();
            Jogo.Grupo1 = new Grupo();
            Jogo.Grupo2 = new Grupo();
            Jogo.TempoPalavra = 180;
            Jogo.Rodadas = 1;

        }
        private void IniciarJogo()
        {
            string error = "";
            if (Jogo.TempoPalavra < 10)
            {
                error += "O tempo minimo para considerar para a palavra é de 10 segundos.";
            }
            if (Jogo.Rodadas <= 0)
            {
                error += "\n O Valor minimo de rodadas a ser considerada deve ser maior que 1.";
            }

            if (error.Length > 0)
            {
                MsgErro = error;
            }
            else
            {
                Armazenamento.Armazenamento.Jogo = this.Jogo;
                Armazenamento.Armazenamento.RodadaAtual = 1;
                App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
            }
    }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string NomeProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NomeProperty));

            }
        }
    }   
}
