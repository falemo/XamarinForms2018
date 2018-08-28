using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1_Mimica.Model;
using Xamarin.Forms;
namespace App1_Mimica.ViewModel
{
    public class ResultadoViewModel:INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }
        public Command JogarNovamente { get; set; }

        public ResultadoViewModel()
        {
            Jogo = Armazenamento.Armazenamento.Jogo;
            JogarNovamente = new Command(JogarNovamenteAction);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string NomeProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NomeProperty));
            }
        }

        private void JogarNovamenteAction()
        {
            App.Current.MainPage = new View.Inicio();
        }

    }
}
