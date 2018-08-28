using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace App1_Mimica.View.Util
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cabecalhos : ContentView
	{
		public Cabecalhos ()
		{
			InitializeComponent ();

            BindingContext = new ViewModel.CabecalhoViewModel();
		}

        public void SairEvento (object sender, EventArgs args)
        {
            var viewmodel = (ViewModel.CabecalhoViewModel)this.BindingContext;

            if (viewmodel.Sair.CanExecute(null))
            {
                viewmodel.Sair.Execute(null);
            }
        }


	}
}