using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Cell.Modelo;

namespace App1_Cell.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageCellPage : ContentPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Cargo = "Gerente TI", Nome = "Pedro", Foto = "http://www.academianiteroiense.org.br/Fotos/Foto%20Jorge%20Vicente.jpg" });
            Lista.Add(new Funcionario() { Cargo = "Analista TI", Nome = "Joaquim", Foto = "http://sil.gobernacion.gob.mx/Archivos/Fotos/2300459.jpg" });
            Lista.Add(new Funcionario() { Cargo = "Programador TI", Nome = "Tereza", Foto= "https://www.cadal.org/fotos/Caecilia_Wijgers_150x188.jpg" });
            Lista.Add(new Funcionario() { Cargo = "Dono TI", Nome = "Elaine", Foto= "http://m.c.lnkd.licdn.com/mpr/mpr/shrinknp_200_200/AAEAAQAAAAAAAAf9AAAAJGQwNTc2ZjJjLTE3YTQtNDJkNS04NzBlLWRlMDE2YmNmOTM4NA.jpg" });
            Lista.Add(new Funcionario() { Cargo = "Presidente TI", Nome = "Guilherme", Foto = "http://sz.navj.us/system/avatars/680482/user_photo.JPG" });
            Lista.Add(new Funcionario() { Cargo = "Entregador TI", Nome = "Madre", Foto = "http://sz.navj.us/system/avatars/680482/user_photo.JPG" });

            ListaFuncionario.ItemsSource = Lista;
        }
	}
}