using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2_ListaBrasil.Modelo;

namespace App2_ListaBrasil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Municipios : ContentPage
	{
        private List<Municipio> ListaMunicipio { get; set; }
        private List<Municipio> ListaFiltradaMunicipio { get; set; }

        public Municipios (Estado estado)
		{
			InitializeComponent ();
            ListaMunicipio = Servico.EstadoServico.GetMunicipio(estado.id);
            ListaMunicipios.ItemsSource = ListaMunicipio;
        }

        private void BuscaRapida(object sender, TextChangedEventArgs args)
        {
            ListaFiltradaMunicipio = ListaMunicipio.Where(a => a.nome.Contains(args.NewTextValue)).ToList();
            ListaMunicipios.ItemsSource = ListaFiltradaMunicipio;

        }


    }
}