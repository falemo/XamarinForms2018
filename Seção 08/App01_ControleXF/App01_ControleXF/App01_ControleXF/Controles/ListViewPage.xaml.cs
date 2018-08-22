using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App01_ControleXF.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewPage : ContentPage
	{
		public ListViewPage ()
		{
			InitializeComponent ();
            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa { Nome = "Pedro Lemos", Idade = "20" });
            lista.Add(new Pessoa { Nome = "Teresa Lemos", Idade = "21" });
            lista.Add(new Pessoa { Nome = "Jeova Lemos", Idade = "22" });
            lista.Add(new Pessoa { Nome = "Tenorio Lemos", Idade = "23" });
            lista.Add(new Pessoa { Nome = "Melagrião Lemos", Idade = "24" });

            ListaPessoa.ItemsSource = lista;

        }
    }
}