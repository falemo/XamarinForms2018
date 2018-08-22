using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchBarPage : ContentPage
	{
        private List<string> EmpresasTI;
        public SearchBarPage ()
		{
			InitializeComponent ();
            EmpresasTI = new List<string>();
            EmpresasTI.Add("Microsoft");
            EmpresasTI.Add("Oracle");
            EmpresasTI.Add("Apple");
            EmpresasTI.Add("FabricaIdeais");
            EmpresasTI.Add("CA");
            EmpresasTI.Add("Symantec");
            EmpresasTI.Add("SAP");
            EmpresasTI.Add("IBM");

            Preencher(EmpresasTI);
           
        }
        private void PesquisarButton(object sender, TextChangedEventArgs args)
        {
            var resultado = EmpresasTI.Where(a => a.Contains(((SearchBar)sender).Text)).ToList<string>();
            Preencher(resultado);
        }
        private void Pesquisar(object sender, TextChangedEventArgs args)
        {
           var resultado= EmpresasTI.Where(a => a.Contains(args.NewTextValue)).ToList<string>();
            Preencher(resultado);
        }
            private void Preencher (List<string> EmpresasTI)
        {
            ListResult.Children.Clear();
            foreach (var emp in EmpresasTI)
            {
                ListResult.Children.Add(new Label { Text = emp });
            }
        }
    }
}